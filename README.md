# Projektni-Zadatak-SBES

Projektni zadatak iz predmeta "Sigurnost i bezbednost u elektroenergetskim sistemima" na FTN-u u Novom Sadu.

Zadatak podrazumeva izradu bezbednosnih mehanizama pri izradi sistema za deljenje privatnih podataka. Komunikacija unutar celog sistema je zasticenja uz pomoc DES enkripcije, i vrsi se autentifikacija svih korisnika u sistemu.

Server kroz svoj interfejs nudi metode za: Registraciju, Promenu lozinke, Login, Logout.

Takodje je omoguceno korisnicima da kreiraju grupe korisnika u sistemu kojima je moguce dati dozvolu pristupa svojim privatnim podacima.

Sistem vodi racuna o sinhronizaciji, sto znaci da kad dodje do promene neke od dozvola pristupa, ta promena se odmah odrazi i kod svih ostalih trenutno ulogovanih korisnika.
