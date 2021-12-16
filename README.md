# KoalaBankApp 

This fictional bank application are built up by different classes and methods for funcionality, The center core of this program/system is the Bank Class where the actual program
runs from, that was the main idea. There are several classes with different functions and where to save information. From the program class we create an object of the class Bank, 
and have a simple Run Method where we have our usermenu and from there calling out different methods for the functions of a bank.

User Class. Where everything is stored and bundled up as an object for each User, like username, first name, last name, an emailadress. There are also several lists 
connected to each user for further information being tied to the user. All these User objects are stored inside a List inside the Bank Class.

BankAccount Class. A class that stores information about a users bankaccounts and each bank account is an object that is being stored inside a list inside the 
User Object, so the bankaccounts will always be linked to the specific user object.

CurrencyRate Class. The idea was to create a class that could carry different types of Currencys and save and store them inside another list which is located
inside Bank Class. So every type of currency that is added are an object of CurrencyRates. And there are also a method inside the CurrencyRate Class which allows the admin to 
Update the currency Rate, there is only one added currency at the moment but you can add different Currencys afterwards and add more funtions for calculations between bankaccounts.

Loans Class. A class to be able to take loans from the bank. It has a random interest method, total balance method, new account balance method and the main method.
The main method is the method the user gets to interact with. The user can only loan a total amount of all accounts * 5.

SavingsAccount Class. The savings account inherits from BankAccount class. The Savings account is a regular bank account, but with interest. The interest is randomized for now,
and does not affect the value of the account.

Transfer Class A class that make it possbile to transfer amounts of money between diffrent accounts both your own and from your own to other users. You can also see a transaction log. Changes made here goes to the User class and stores itself in the correct users account so if u log out and in the changes is saved 

Transaction Class A class that stores info about transfers that have been done in the transfer class. We have a task here that updates the transaction log in transfer class every 15 minutes example: 10:00 - 10:15 - 10:30 - 10:45.

Login Class
