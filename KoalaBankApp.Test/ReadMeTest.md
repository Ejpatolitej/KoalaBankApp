#Områden för testing

Dom tre områden som jag har valt var Transfer, Users, och Loans.
Dom är speciellt intressanta i affärssyfte, dels för pengar och dels för säkerhet.

##Vad kan gå fel

Saker som kan gå fel i denna koden kan vara att man får mer pengar än man tänkt, att pengarna inte hamnar rätt, att lösenord blir fel m.m.
Jag kommer testa att flytta pengar i Transfer delen, jag kommer testa att skapa en ny användare i Users delen, och att låna pengar i Loans.


##Slutsats

Jag upptäckte snabbt att våran kod var otroligt krånglig och svår att hantera. Jag fick kommentera bort väldigt mycket bara för att få
metoderna att fungera som jag ville.
Den lättaste delen var Loans, där behövde jag inte göra så mycket, men det var också en enklare metod.

Hade jag gjort om koden mer så hade jag nog flyttat ut flera metoder så att dom blir enklare att testa och lättare att hantera.
Just nu är metoderna väldigt långa och onödigt krångliga på många ställen.

Mina tester kan absolut utvecklas, dom behöver lite mer djup, men just nu har jag väldigt begränsad kunskap.
Det hade varit intressant att försöka knäcka koden lite. Testa sig fram i vad för säkerhet som programmet har, eller snarare inte har.

Jag skulle nog vilja testa något mer än "Equals" och "IsNotNull" men som sagt har jag väldigt begränsad kunskap, och det känns som att
jag skulle vilja förstå mer av unit testing innan jag kan göra ett mer intressant test.
