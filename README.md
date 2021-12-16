# KoalaBankApp 

## This fictional bank application is built up by different classes and methods for funcionality. The core of this program/system is the Bank Class where the actual program runs from, that is the main idea. There are several classes with different functions and to save information. From the program class we create an object of the class Bank, and have a simple Run Method where we have our usermenu and from there calling out different methods for the functions of the bank.

### User Class
Where everything is stored and bundled up as an object for each User. They are username, password, first name, last name, and email. There are also several lists 
connected to each user for further information being tied to the user. All these User objects are stored inside a List inside the Bank Class.

### BankAccount Class
Stores information about a users bank accounts. Each bank account is an object that is being stored in a list inside the 
User Object, so the bank accounts will always be linked to the specific user object.

### CurrencyRate Class
The idea was to create a class that could carry different types of currencies and save and store them in a list which is located
inside the Bank Class. Every type of currency that is added is an object of CurrencyRates. There is also a method inside the CurrencyRate Class which allows the admin to 
update the currency rate. There is only one added currency at the moment, but it is possible to add different currencies afterwards and add more funtions for calculations between bank accounts.

### Loans Class
Lets you take loans from the bank. It has a random interest method, total balance method, new account balance method and the main method.
The main method is the method the user gets to interact with. The user can only loan a total amount of all accounts * 5.

### SavingsAccount Class
The savings account inherits from BankAccount class. The Savings account is a regular bank account, but with interest. The interest is randomized for now,
and does not affect the value of the account.

### Transfer Class
Makes it possbile to transfer money between different accounts. Both your own, and to other users. You can also see a transaction log. Changes made here goes to the User class and stores itself in the correct users account, so if you log out the changes are saved 

### Transaction Class
Stores info about transfers that have been done in the transfer class. We have a task here that updates the transaction log in transfer class every 15 minutes example: 10:00 - 10:15 - 10:30 - 10:45.

### Login Class



## Flowchart:

![Untitled](https://user-images.githubusercontent.com/91310995/146374036-2594f5be-3d83-4584-b9ce-a560d11100a9.png)

## [Link to UML](https://lucid.app/lucidchart/e88b86ce-305a-4ca2-b78b-092508cf6f0b/edit?invitationId=inv_e7343318-15a7-45b1-863b-34720ade90b8&page=0_0#)
