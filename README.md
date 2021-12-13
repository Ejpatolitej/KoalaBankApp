# KoalaBankApp 

This fictional bank application are built up by different classes and methods for funcionality, The center core of this program/system is the Bank Class where the actual program
runs from, that was the main idea. There are several classes with different functions and where to save information. From the program class we create an object of the class Bank, 
and have a simple Run Method where we have our usermenu and from there calling out different methods for the functions of a bank.

User Class is where everything is stored and bundled up as an object for each User, like username, first name, last name, an emailadress. There are also several lists 
connected to each user for further information being tied to the user. All these User objects are stored inside a List inside the Bank Class.

BankAccount Class, which is a class that stores information about a users bankaccounts and each bank account is an object that is being stored inside a list inside the 
User Object, so the bankaccounts will always be linked to the specific user object.

CurrencyRate Class, the idea was to create a class that could carry different types of Currencys and save and store them inside another list which is located
inside Bank Class. So every type of currency that is added are an object of CurrencyRates. And there are also a method inside the CurrencyRate Class which allows the admin to 
Update the currency Rate, there is only one added currency at the moment but you can add different Currencys afterwards and add more funtions for calculations between bankaccounts.

Loans Class

SavingsAccount Class

Transfer Class

Transaction Class

Login Class
