<!-- # Inicijalne upute za prijavu projekta iz Razvoja programskih proizvoda

Poštovane kolegice i kolege, 

čestitamo vam jer ste uspješno prijavili svoj projektni tim na kolegiju Razvoj programskih proizvoda, te je za vas automatski kreiran repozitorij koji ćete koristiti za verzioniranje vašega koda, ali i za pisanje dokumentacije.

Ovaj dokument (README.md) predstavlja **osobnu iskaznicu vašeg projekta**. Vaš prvi zadatak je **prijaviti vlastiti projektni prijedlog** na način da ćete prijavu vašeg projekta, sukladno uputama danim u ovom tekstu, napisati upravo u ovaj dokument, umjesto ovoga teksta.

Za upute o sintaksi koju možete koristiti u ovom dokumentu i kod pisanje vaše projektne dokumentacije pogledajte [ovaj link](https://guides.github.com/features/mastering-markdown/).
Sav programski kod potrebno je verzionirati u glavnoj **master** grani i **obvezno** smjestiti u mapu Software. Sve artefakte (npr. slike) koje ćete koristiti u vašoj dokumentaciju obvezno verzionirati u posebnoj grani koja je već kreirana i koja se naziva **master-docs** i smjestiti u mapu Documentation.

Nakon vaše prijave bit će vam dodijeljen mentor s kojim ćete tijekom semestra raditi na ovom projektu. Mentor će vam slati povratne informacije kroz sekciju Discussions također dostupnu na GitHubu vašeg projekta. A sada, vrijeme je da prijavite vaš projekt. Za prijavu vašeg projektnog prijedloga molimo vas koristite **predložak** koji je naveden u nastavku, a započnite tako da kliknete na *olovku* u desnom gornjem kutu ovoga dokumenta :) -->

# Naziv projekta
Schedule Manager

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Matej Desanić | mdesanic21@foi.hr | 0016155191 | mdesanic21
Darijo Bračić | dbracic21@foi.hr | 0016156370 | dbracic21-foi 
Ivan Juras | ijuras21@foi.hr | 0016156344 | ijuras21 
## Opis domene
Realizacija softvera koja će služiti organizatorima posla u poslovima gdje se prodaju usluge, na primjer usluga čišćenja, pranja auta itd. Ideja je da organizator posla ima uvid u raspored svakog zaposlenika, pa prilikom dogovora pružanja usluge može dogovoriti kojeg će zaposlenika staviti za tu dogovorenu uslugu. Softver može pamtiti kupce koji su koristili usluge, točnije imat će bazu klijenata koji su već koristili uslugu i isto tako će imati izvještaje na kraju mjeseca. Softver mogu koristiti i radnici koji će moći vidjeti svoj raspored sa svim potrebnim informacijama.

<!--Umjesto ovih uputa opišite domenu ili problem koji pokrivate vašim  projektom. Domena može biti proizvoljna, ali obratite pozornost da sukladno ishodima učenja, domena omogući primjenu zahtijevanih koncepata kako je to navedeno u sljedećem poglavlju. Priložite odgovarajuće skice gdje je to prikladno.-->

## Specifikacija projekta
<!--Umjesto ovih uputa opišite zahtjeve za funkcionalnošću programskog proizvoda. Pobrojite osnovne funkcionalnosti i za svaku naznačite ime odgovornog člana tima. Opišite buduću arhitekturu programskog proizvoda. Obratite pozornost da bi arhitektura trebala biti višeslojna s odvojenom (dislociranom) bazom podatka koju ćemo za vas mi pripremiti i dati vam pristup naknadno. Također uzmite u obzir da bi svaki član tima treba biti odgovorana za otprilike 3 funkcionalnosti, te da bi opterećenje članova tima trebalo biti ujednačeno. Priložite odgovarajuće dijagrame i skice gdje je to prikladno. Funkcionalnosti sustava bobrojite u tablici ispod koristeći predložak koji slijedi:-->

Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Login | Za pristup Schedule Manageru potrebnba je autentikacija korisnika pomoću login funkcionalnosti. Korisnik se logira s podacima koji su mu dodijeljeni prilikom zaposlenja. Imat će dvije uloge zaposlenik i organizator posla | Darijo Bračić
F02 | Zapisivanje podataka o zaposleniku | Sustav će omogućiti zapisivanje podataka o zaposleniku isključivo korisniku uloge organizator posla | Matej Desanić
F03 | Izrada rasporeda sati  | Sustav će omogučiti organizatoru posla da izradi raspored i doda svoje zaposlenike, a zaposlenici imaju mogučnost jedino da pregledaju raspored. | Ivan Juras
F04 | Omogućavanje ponavljajuće usluge | Sustav će omogućiti definiranje usluge koja se učestalo dešavaju. | Darijo Bračić
F05 | Omogućavanje izradde izvještaja  | Sustav će omogučiti korinsiku izradu izvještaja u nekom vremenskom intervalu.| Matej Desanić
F06 | Automatsko slanje maila   | Sustav će korinsiku slati mail podsjetnik dan prije izvršavanja usluge.  | Ivan Juras
F07 | Zapis podataka o klijentu|  Sustav će omogučavati organizatoru posla dodavanje novih klijenata u bazu podataka. | Darijo Bračić
F08 | Izrada rasporeda u obliku PDF-a | Sustav će omogučiti svakom korisniku preuzimanje rasporeda u obliku PDF-a. | Matej Desanić
F09 | Otkrivanje dodatnih informacija  | Sustav će omogučiti otkirvanje dodatnih informacija klikom na pojedinu stavku rasporeda.  | Ivan Juras

## Tehnologije i oprema
<!--Umjesto ovih uputa jasno popišite sve tehnologije, alate i opremu koju ćete koristiti pri implementaciji vašeg rješenja. Projekti se razvijaju koristeći .Net Framework ili .Net Core razvojne okvire, a vrsta projekta može biti WinForms, WPF i UWP. Ne zaboravite planirati korištenje tehnologija u aktivnostima kao što su projektni menadžment ili priprema dokumentacije. Tehnologije koje ćete koristiti bi trebale biti javno dostupne, a ako ih ne budemo obrađivali na vježbama u vašoj dokumentaciji ćete morati navesti način preuzimanja, instaliranja i korištenja onih tehnologija koje su neopbodne kako bi se vaš programski proizvod preveo i pokrenuo. Pazite da svi alati koje ćete koristiti moraju imati odgovarajuću licencu. Što se tiče zahtjeva nastavnika, obvezno je koristiti git i GitHub za verzioniranje programskog koda, GitHub Wiki za pisanje tehničke i projektne dokumentacije, a projektne zadatke je potrebno planirati i pratiti u alatu GitHub projects.--> 

Projekt će biti izrađen u .Net Framework-u, a vrsta projekta će biti izrađena u WPF-u. 
