# Kodanalys

## Problem hittade
1. ```class program``` ska helst starta med en stor bokstav: ```class Program```.
2.	#### Dåliga namn på variabler och inmatningar (är inte "korrekt" beskrivande):
	1. ```unicornSparkle```
	2. ```celestialWhispers```
	3. ```strUsr```
	4. ```entitetsExcisionIdentifierare```
	5. ```nanoBanana```
	6. ```nebulousQuery```
	7. ```magicConstant```
	8. ```bool f00l```
3. Koden är en röra och saknar struktur. Det är svårt att läsa och förstå vad som händer. Bättre att dela upp koden i filer och metoder.
4. Models/User används inte, och är onödig.
5. “Lista användare” kan behöva en check om inga användare finns.
6. Inget meddelande om en användare har lagts till, eller tagits bort.
7. Använda List<string> istället för "fast" Array.
8. När en användare tas bort flyttas elementen, men sista elementet i arrayen lämnas kvar, vilket kan leda till minnesläckage.
9. Foreach-loop passar bättre än for-loop (även fast for-loopar är "tekniskt" snabbare).
10. Originalkoden kollar inte om användare med angivna namn redan finns (inte skiftlägeskänslig), i varken att skapa, radera, eller söka användare.
11. Originalkoden kollar inte om namn är tomma, eller innehåller ogiltiga tecken (icke-bokstäver eller flera ord).
12. Ingen validering av inmatningar (till exempel kontroll för ```null```).
13. Användare kan lägga till samma namn flera gånger (t.ex. "Anna" kan läggas till 3 gånger).
14. Ingen .Trim() på inmatningar, vilket kan leda till problem med extra mellanslag.

## Vad gör den nya koden bättre?
Först av allt så är den nya koden renare, säkrare och enklare att underhålla. Den är dessutom mer framtidssäker, då om man till exempel skulle vilja kunna ha fler användare, så är det superlätt att fixa, eftersom det nu är ingen manuell array-hantering.
Med andra ord; långsiktigt så är kodkvalitén mycket bättre. Det är enklare att bygga ut på koden.  
Dessutom så är den nya koden bättre strukturerad, och därmed enklare att läsa och förstå.

En nackdel är att det inte fanns någon kontroll för tomma namn; den originella koden accepterar tomma namn. Men det är nu fixat i min kod, och det är en förbättring.

*Manuell skift-logik:* kod för att ta bort element kopierar efterföljande element ett steg till vänster. Detta är repetitivt, utsatt för fel, och onödigt när kollektioner erbjuder denna funktion.
Med andra ord, så behövs inte manuell bokföring i min kod (```userCount``` till ```userList.Count```).

Jag använder mig av helper-metoder, vilket håller det i linje med DRY-principen. Till exempel så har jag skapat en metod som validerar namn; 
den metoden kollar om namnet inte är tomt och om det bara är bokstäver, samt om namnet är max ett ord.
Mycket bättre än att upprepa samma kod flera gånger i olika delar av programmet.

Att koden dessutom nu är splittrad gör koden enklare att förstå: 
menyn hanteras i sin egna fil och klass; detsamma med metoder relaterat till användare. Detta gör koden mycket mer framtidssäker, och enklare att underhålla. Det finns bara fördelar med detta.

Till sist så är min kod kommenterad, vilket gör det enklare att förstå vad som händer.

*Exempel på förbättringar:*

```
for (int i = index; i < userCount - 1; i++) {
    userList[i] = userList[i + 1];
}
userCount--;
```
I koden ovan så hanteras arrayen manuellt, vilket är onödigt och felbenäget. Till skillnade från detta:
```
userList.RemoveAll(u => string.Equals(u, nameInput, StringComparison.OrdinalIgnoreCase));
```

Samma sak med sökningsfunktionen:
```
bool found = false;
for (int i = 0; i < userCount; i++) {
    if (userList[i] == searchName) {
        found = true;
        break;
    }
}
```

Istället för att gå igenom varje användare i listan manuellt—och sedan vid positivt resultat sätta en bool till true, för att använda utanför loopen—är inte det snyggaste sättet att göra det på.
Istället så är exemplet nedan enklare, snabbare, snyggare, och kortare:
```
if (userList.Exists(u => string.Equals(u, searchName, StringComparison.OrdinalIgnoreCase))) {
    ...
}
```