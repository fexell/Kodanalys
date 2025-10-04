# Kodanalys

## Problem hittade
1. ```class program``` ska helst starta med en stor bokstav: ```class Program```.
2.	#### D�liga namn p� variabler och inmatningar (�r inte "korrekt" beskrivande):
	1. ```unicornSparkle```
	2. ```celestialWhispers```
	3. ```strUsr```
	4. ```entitetsExcisionIdentifierare```
	5. ```nanoBanana```
	6. ```nebulousQuery```
	7. ```magicConstant```
	8. ```bool f00l```
3. Koden �r en r�ra och saknar struktur. Det �r sv�rt att l�sa och f�rst� vad som h�nder. B�ttre att dela upp koden i filer och metoder.
4. Models/User anv�nds inte, och �r on�dig.
5. �Lista anv�ndare� kan beh�va en check om inga anv�ndare finns.
6. Inget meddelande om en anv�ndare har lagts till, eller tagits bort.
7. Anv�nda List<string> ist�llet f�r "fast" Array.
8. N�r en anv�ndare tas bort flyttas elementen, men sista elementet i arrayen l�mnas kvar, vilket kan leda till minnesl�ckage.
9. Foreach-loop passar b�ttre �n for-loop (�ven fast for-loopar �r "tekniskt" snabbare).
10. Originalkoden kollar inte om anv�ndare med angivna namn redan finns (inte skiftl�gesk�nslig), i varken att skapa, radera, eller s�ka anv�ndare.
11. Originalkoden kollar inte om namn �r tomma, eller inneh�ller ogiltiga tecken (icke-bokst�ver eller flera ord).
12. Ingen validering av inmatningar (till exempel kontroll f�r ```null```).
13. Anv�ndare kan l�gga till samma namn flera g�nger (t.ex. "Anna" kan l�ggas till 3 g�nger).
14. Ingen .Trim() p� inmatningar, vilket kan leda till problem med extra mellanslag.

## Vad g�r den nya koden b�ttre?
F�rst av allt s� �r den nya koden renare, s�krare och enklare att underh�lla. Den �r dessutom mer framtidss�ker, d� om man till exempel skulle vilja kunna ha fler anv�ndare, s� �r det superl�tt att fixa, eftersom det nu �r ingen manuell array-hantering.
Med andra ord; l�ngsiktigt s� �r kodkvalit�n mycket b�ttre. Det �r enklare att bygga ut p� koden.  
Dessutom s� �r den nya koden b�ttre strukturerad, och d�rmed enklare att l�sa och f�rst�.

En nackdel �r att det inte fanns n�gon kontroll f�r tomma namn; den originella koden accepterar tomma namn. Men det �r nu fixat i min kod, och det �r en f�rb�ttring.

*Manuell skift-logik:* kod f�r att ta bort element kopierar efterf�ljande element ett steg till v�nster. Detta �r repetitivt, utsatt f�r fel, och on�digt n�r kollektioner erbjuder denna funktion.
Med andra ord, s� beh�vs inte manuell bokf�ring i min kod (```userCount``` till ```userList.Count```).

Jag anv�nder mig av helper-metoder, vilket h�ller det i linje med DRY-principen. Till exempel s� har jag skapat en metod som validerar namn; 
den metoden kollar om namnet inte �r tomt och om det bara �r bokst�ver, samt om namnet �r max ett ord.
Mycket b�ttre �n att upprepa samma kod flera g�nger i olika delar av programmet.

Att koden dessutom nu �r splittrad g�r koden enklare att f�rst�: 
menyn hanteras i sin egna fil och klass; detsamma med metoder relaterat till anv�ndare. Detta g�r koden mycket mer framtidss�ker, och enklare att underh�lla. Det finns bara f�rdelar med detta.

Till sist s� �r min kod kommenterad, vilket g�r det enklare att f�rst� vad som h�nder.

*Exempel p� f�rb�ttringar:*

```
for (int i = index; i < userCount - 1; i++) {
    userList[i] = userList[i + 1];
}
userCount--;
```
I koden ovan s� hanteras arrayen manuellt, vilket �r on�digt och felben�get. Till skillnade fr�n detta:
```
userList.RemoveAll(u => string.Equals(u, nameInput, StringComparison.OrdinalIgnoreCase));
```

Samma sak med s�kningsfunktionen:
```
bool found = false;
for (int i = 0; i < userCount; i++) {
    if (userList[i] == searchName) {
        found = true;
        break;
    }
}
```

Ist�llet f�r att g� igenom varje anv�ndare i listan manuellt�och sedan vid positivt resultat s�tta en bool till true, f�r att anv�nda utanf�r loopen��r inte det snyggaste s�ttet att g�ra det p�.
Ist�llet s� �r exemplet nedan enklare, snabbare, snyggare, och kortare:
```
if (userList.Exists(u => string.Equals(u, searchName, StringComparison.OrdinalIgnoreCase))) {
    ...
}
```