# EdHouse_Ukol_Vcely
Stáž 2023 - Zachraň Včelku Máju!
Božínku! Včelka Mája a celé její společenstvo včel přišli o domov! Musíš jí a nespočtu jejích včelích sourozenců pomoci najít vhodné místo pro stavbu nového úlu. Naštestí nemusíš hledat v celém širém kraji. Včelkám se totiž zamlouvá místo zvané Pravidelný háj, kde jsou stromy vysázeny v pravidelné mřížce. Tvým úkolem je zjistit, zda je Pravidelný háj pro včelstvo bezpečný. Máju zajíma kolik stromů Pravidelného háje je možné spatřit z jeho vnějšku, díváme-li se výhradně podél řad, či sloupců. 
Mapování Pravidelného háje je pro včelky hračka. Rozletí se do všech směrů a nezbývá než počkat co nám povědí. Aby Ti Mája mohla dobře vysvětlit jak máš postupovat, nakreslila ti v mezičase nejdříve malou mapu jako příklad:
Příklad

30373
25512
65332
33549
35390

Každý strom je reprezentován jednou číslicí, jejíž hodnota odpovída výšce stromu, kde 0 je nejmenší a 9 je nejvyšší
Strom je viditelný pokud jsou všechny ostatní stromy mezi ním a okrajem Pravidelného háje kratší. Uvažujte pouze stromy ve stejné řadě, nebo sloupci. Zjednodušeně řečeno: dívejte se pouze nahoru, dolů, doleva nebo doprava směrem od daného stromu.
Všechny stromy na okraji háje jsou viditelné – jsou totiž na okraji a žádný strom je proto nemůže zakrýt.
V příkladu výše tedy stačí zkoumat vnitřních devět stromů:
•	Pětka vlevo nahoře je viditelná zleva a shora (není viditelná zprava či zespoda protože v těchto směrech jsou jiné stromy výšky 5.
•	Pětka nahoře uprostřed je viditelná shora a zprava.
•	Jednička nahoře vpravo není viditelná odnikud. Abychom ji mohli spatřit, musely by mezi ní a okrajem být pouze stromy výšky 0.
•	Pětka vlevo uprostřed je viditelná, byť pouze zprava.
•	Trojka přesně uprostřed není viditelná odnikud. Aby tomu tak bylo, musely by směrem k okrají růst pouze stromy velikosti nejvýše 2.
•	Trojka vpravo uprostřed je viditelná zprava.
•	Ve spodní řadě můžeme z okraje spatřit pouze pětku. Trojku a čtverku nikoliv.
Sečteno máme 16 stromů viditelných na okraji a dalších 5 uvnitř a celkem tedy 21 stromů viditelných v uspořádání příkladu.
Vstupní data
Najednou slyšíš bzučení. Jsou to včelky, které se postupně slétají k Máji a šeptají ji svá pozorování. Netrvá dlouho než ti Mája předá skutečnou mapu pravidelného háje (textový soubor vložený do tohoto MS Word dokumentu)
 
Kolik stromů Pravidelného háje můžeme spatřit zvenku?
Pokyny
-	Zvolte jazyk a prostředí dle preference – C++ / C# / Java / Python / Rust / JavaScript
-	Napište program, který
o	Načte data ze standardního vstupu (STDIN)
o	 co nejefektivněji vyřeší výše popsaný úkol
o	Vypíše odpověď na standardní výstup (STDOUT)
-	Na adresu specifikovanou v průvodním e-mailu, nejpozději do data uvedeného tamtéž zašlete e-mail, obshaující
o	V textu emailu – popis Vámi zvoleného prostředí a zejména instrukce k přeložení a spuštění vašeho programu
o	V textu emailu - popis použitého algoritmu
o	V textu emailu – vypočtenou hodnotu
o	V příloze pak přeložitelný (či interpretovatelný) program ve formě zdrojových kódu a všech dalších potřebných projektových souborů.
