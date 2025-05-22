# BudgetPlanner

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

## MVP-tavoitteet

- [] Kulujen lisääminen
- [] Kulujen poisto ja päivitys
- [] Tietokantarakenne EF Corella
- [ ] Token-autentikointi
- [ ] Käyttäjätunnusten luominen
- [ ] Sisäänkirjautuminen ja uloskirjautuminen
- [ ] Toistuvien kulujen kasittely automaattisesti
- [ ] Maksutilan merkintä (IsPaid)
- [ ] Kulujen lajittelu ja suodatus (maksamattomat, toistuvat, jne)
- [ ] Kuukausittainen yhteenveto
- [ ] Mahdollisuus syöttää kuukausitulot

---

## Suunnitteluperiaate

- Alkuvaiheessa keskitytään kulujen hallintaan
- Käyttäjät lisätään myöhemmässä vaiheessa
- Rakennetaan ensin vahva tietokantarakenne
- Enum-arvot kuten RecurringType ja Category tallennetaan tauluihin integer-arvoina, ja muutetaan tekstiksi haettaessa
- LastOccurrDate-taulu sisältää toistuvan kulun viimeisimmän tapahtuman, jonka perusteella lasketaan seuraava maksupäivä

---

© Markus Wahlroos 2025
