using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouse_Ukol_Vcely
{
    internal class Forest
    {
        internal Tree[,] trees;
        internal readonly int width;
        internal readonly int height;
        public int TotalVisibleTrees { get => GetEnumerator().Count(tree => tree.isVisible); }
        public int TreesOnEdges { get => 2 * width + 2 * (height - 2); }
        public int TreesVisibleInsideForest { get => TotalVisibleTrees - TreesOnEdges; }
        internal Forest(int width, int height, in int[,] treeHeights)
        {
            trees = new Tree[width, height];
            trees = FillInForest(trees, treeHeights, width, height);
            this.width = width;
            this.height = height;
        }

        private static Tree[,] FillInForest(in Tree[,] trees, in int[,] treeHeights, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    trees[i, j] = new Tree(new Coordinate(i, j), treeHeights[i, j]);
                }
            }
            return trees;
        }

        public Tree this[int row, int column]
        {
            get => trees[row, column];
        }

        internal void DetermineTreeVisibilityFromOutside()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tree tree = trees[i, j];
                    bool onTop = i == 0;
                    bool onBottom = i == width - 1;
                    bool onLeft = j == 0;
                    bool onRight = j == height - 1;

                    bool isOnEdge = onTop || onBottom || onLeft || onRight;
                    // assign only if tree is on edge
                    tree.isVisible = isOnEdge ? isOnEdge : tree.isVisible;
                    //if (!onTop && !onBottom && onLeft && !onRight) 
                    switch ((onTop, onBottom, onLeft, onRight))
                    {
                        case (false, false, true, false):
                            //MarkVisibleTreesFromLeft(i);
                            break;
                        case (false, false, false, true):
                            //MarkVisibleTreesFromRight(i);
                            break;
                        case (true, false, false, false):
                            MarkVisibleTreesFromTop(j);
                            break;
                        case (false, true, false, false):
                            //MarkVisibleTreesFromBottom(j);
                            break;
                    }
                }
            }
        }

        private void MarkVisibleTreesFromLeft(int row)
        {
            for (int i = 1; i < width - 1; i++)
            {
                Tree currentTree = trees[row, i];
                Tree treeToLeft = trees[row, i - 1];
                if (currentTree.height > treeToLeft.height)
                {
                    currentTree.isVisible = true;
                }
                else if (currentTree.height == treeToLeft.height) continue;
                else return;
            }
        }

        private void MarkVisibleTreesFromRight(int row)
        {
            for (int i = width - 2; i > 0; i--)
            {
                Tree currentTree = trees[row, i];
                Tree treeToRight = trees[row, i + 1];
                if (currentTree.height > treeToRight.height)
                {
                    currentTree.isVisible = true;
                }
                else if (currentTree.height == treeToRight.height) continue;
                else return;
            }
        }

        private void MarkVisibleTreesFromTop(int column)
        {
            for (int i = 1; i < height - 1; i++)
            {
                Tree currentTree = trees[i, column];
                Tree treeToTop = trees[i - 1, column];
                if (currentTree.height > treeToTop.height)
                {
                    currentTree.isVisible = true;
                }
                else if (currentTree.height == treeToTop.height) continue;
                else return;
            }
        }

        private void MarkVisibleTreesFromBottom(int column)
        {
            for (int i = height - 2; i > 0; i--)
            {

                Tree currentTree = trees[i, column];
                Tree treeToBottom = trees[i + 1, column];
                if (currentTree.height > treeToBottom.height)
                {
                    currentTree.isVisible = true;
                }
                else if (currentTree.height == treeToBottom.height) continue;
                else return;
            }
        }

        public IEnumerable<Tree> GetEnumerator()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    yield return trees[i, j];
                }
            }
        }
    }
}
