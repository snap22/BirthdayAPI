# BirthdayAPI
Jednoduché REST API pre správu poznámok, kontaktov a ich darčekov  

## Využité technológie
ASP.NET Core, MS EF Core, Swagger, AutoMapper, FluentValidation

## Stručný prehľad requestov
### Accounts
Účty užívateľov  

| Type | URL | Response |
| ------------- | ------------- | ------------- |
| **GET**  | /api/Accounts | Vráti zoznam účtov  |
| **GET**  | /api/Accounts/{id}  | Vráti účet so zadaným id |
| **POST**  | /api/Accounts  | Vytvorí nový účet so zadanými údajmi |
| **PUT** | /api/Accounts/{id}  | Upraví účet s daným id |
| **DELETE** | /api/Accounts/{id}  | Vymaže účet s daným id |

Schéma   
```javascript
{
  "accountId": 0,
  "email": "string",
  "password": "string",
  "dateCreated": "string"
}
```
  
### Profiles
Profily pre jednotlivé účty 

| Type | URL | Response |
| ------------- | ------------- | ------------- |
| **GET**  | /api/Profiles | Vráti zoznam profilov  |
| **GET**  | /api/Profiles/{id}  | Vráti profil so zadaným id |
| **GET**  | /api/Profiles/Account/{accountId}  | Vráti profil daného účtu |
| **POST**  | /api/Profiles  | Vytvorí nový profil so zadanými údajmi |
| **PUT** | /api/Profiles/{id}  | Upraví profil s daným id |
| **DELETE** | /api/Profiles/{id}  | Vymaže profil s daným id |

Schéma   
```javascript
{
  "profileId": 0,
  "username": "string",
  "bio": "string",
  "accountId": 0
}
```

### Contacts
Kontakty, ktoré predstavujú konkrétne osoby, pre ktoré by užívateľ chcel plánovať darčeky  

| Type | URL | Response |
| ------------- | ------------- | ------------- |
| **GET**  | /api/Profiles/{profileId}/Contacts | Vráti zoznam kontaktov pre daný profil  |
| **GET**  | /api/Profiles/{profileId}/Contacts/{contactId}  | Vráti kontakt so zadaným id daného profilu |
| **POST**  | /api/Profiles/{profileId}/Contacts  | Vytvorí nový kontakt pre daný profil |
| **PUT** | /api/Profiles/{profileId}/Contacts/{contactId}  | Upraví kontakt daného profilu |
| **DELETE** | /api/Profiles/{profileId}/Contacts/{contactId}  | Vymaže kontakt daného profilu |

Schéma   
```javascript
{
  "contactId": 0,
  "name": "string",
  "info": "string",
  "date": "string",
  "profileId": 0
}
```

### Gifts
Konkrétne nápady na darčeky pre jednotlivé kontakty  

| Type | URL | Response |
| ------------- | ------------- | ------------- |
| **GET**  | /api/Profiles/{profileId}/Contacts/{contactId}/Gifts | Vráti zoznam darčekov pre daný kontakt  |
| **GET**  | /api/Profiles/{profileId}/Contacts/{contactId}/Gifts/{giftId}  | Vráti daný darček daného kontaktu |
| **POST**  | /api/Profiles/{profileId}/Contacts/{contactId}/Gifts  | Vytvorí nový darček pre daný kontakt |
| **PUT** | /api/Profiles/{profileId}/Contacts/{contactId}/Gifts/{giftId}  | Upraví darček daného kontaktu |
| **DELETE** | /api/Profiles/{profileId}/Contacts/{contactId}/Gifts/{giftId}  | Vymaže darček daného kontaktu |

Schéma   
```javascript
{
  "giftId": 0,
  "name": "string",
  "description": "string",
  "estimatedPrice": 0,
  "contactId": 0
}
```


### Notes
Pomocné poznámky pre profil  

| Type | URL | Response |
| ------------- | ------------- | ------------- |
| **GET**  | /api/Profiles/{profileId}/Notes | Vráti zoznam poznámok pre daný profil  |
| **GET**  | /api/Profiles/{profileId}/Notes/{noteId}  | Vráti poznámku pre daný profil |
| **POST**  | /api/Profiles/{profileId}/Notes  | Vytvorí novú poznámku pre daný profil |
| **PUT** | /api/Profiles/{profileId}/Notes/{noteId}  | Upraví poznámku daného profilu |
| **DELETE** | /api/Profiles/{profileId}/Notes/{noteId}  | Vymaže poznámku daného profilu |

Schéma   
```javascript
{
  "noteId": 0,
  "title": "string",
  "description": "string",
  "profileId": 0
}
```

