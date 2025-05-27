# BudgetPlanner

AI used for brainstorming, planning and teaching.


## Tietokanta (vaihe 1)

### Taulu: Expenses

| Sarake        | Tyyppi     | Kuvaus                         |
|---------------|------------|--------------------------------|
| ExpenseId     | int        | Pääavain                      |
| Description   | string     | Selite                        |
| Cost          | decimal    | Hinta                         |
| ExpenseDate   | datetime   | Päivämäärä                    |
| RecurringTypeId | int      | Viittaus toistuvuustyyppiin   |
| CategoryId    | int        | Viittaus kategoriaan          |
| IsPaid        | bool       | Onko maksettu vai ei          |

### Taulu: RecurringTypes

| Sarake           | Tyyppi   | Kuvaus                                |
|------------------|----------|---------------------------------------|
| RecurringTypeId  | int (PK) | Esim. 0 = Kertakulu, 1 = Kuukausittain |
| Name             | string   | Tyyppi tekstinä                       |

### Taulu: Categories

| Sarake     | Tyyppi   | Kuvaus                   |
|------------|----------|--------------------------|
| CategoryId | int (PK) | Kategorian tunniste      |
| Name       | string   | Esim. Ruoka, Asuminen    |

### Taulu: LastOccurrDate (vain toistuvat kulut)

| Sarake     | Tyyppi   | Kuvaus                            |
|------------|----------|-----------------------------------|
| ExpenseId  | int      | Viittaus Expenses-tauluun         |
| UserId     | int      | Viittaus käyttäjään               |
| LastOccur  | datetime | Edellinen toistumispäivä          |

---

## Tavoitteet

Kulujen lisääminen <br>
Kulujen poisto ja päivitys<br>
Tietokantarakenne EF Corella<br>
Token-autentikointi<br>
Käyttäjätunnusten luominen<br>
Sisäänkirjautuminen ja uloskirjautuminen<br>
Toistuvien kulujen kasittely automaattisesti<br>
Maksutilan merkintä (IsPaid)<br>
Kulujen lajittelu ja suodatus (maksamattomat, toistuvat, jne)<br>
Kuukausittainen yhteenveto<br>
Mahdollisuus syöttää kuukausitulot<br>

---


© Markus Wahlroos 2025
