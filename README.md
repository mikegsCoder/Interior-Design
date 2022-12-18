# Interior-Design

:dart:  My project for the [ASP.NET Advanced](https://softuni.bg/trainings/3854/asp-net-advanced-october-2022) course at SoftUni (October 2022). This is a Web application where you can order furniture, browse gallery with design images and send contact messages to the Interior Desing team.
There are roles for Employee and Administrator inplemented. Implemented application email sender using Sendgrid. Implemented company chat using SignalR. The project is deployed on Azure.

## 🔗 **Link to the project:**
&nbsp;&nbsp;&nbsp;&nbsp;**[Interior Design](https://interiordesign.azurewebsites.net/)**

## :arrow_forward: Getting Started:

1. Clone the repo.
   ```sh
   git clone https://github.com/mikegsCoder/Interior-Design.git
   ```
2. Open the solution with Visual Studio 2022.
   
3. Fix the Connection String if you need to do this. You can find it in the appsettings.json file.
   
4. Start InteriorDesign.Web project. On startup InteriorDesign database will be created in your MS SQL Server and the data will be seeded.
   
5. To start tests open Text Explorer and run all tests.
   
5. To test code coverage if you don't use Visual Studio Enterprise - open Package Manager console and start the tests manually with the command given below. As a result all tests will be executed and report will be generated for you in TestResults folder in InteriorDesign.Tests project. The result will be in XML format.
   ```sh
   dotnet test --collect:"XPlat Code Coverage"
   ```

## :information_source: Application Functionality:

- Guest visitors can: 
  - Browse product categories;
  - Browse product types;
  - Browse all products;
  - Browse About Us page and Testimonials;
  - Browse Our Team page;
  - Browse Gallery page;
  - Browse Contact page and send messages to Interior Design team;
  - Browse Register page and create new registration. Application supports external authentication with Google plus and Facebook;
  - Browse Login page and login to application.
- Logged in users can:
  - Add products to their shopping cart; 
  - Edit configured products in their shopping cart;
  - Delete configured products from their shopping cart;
  - Make order. Incase of successful order application email sender sends email to the user with his order status.
- Employee can:
  - Browse Employee Panel with information about configured products, orders, order value, new contacts and messages in company chat; 
  - Browse new orders and ship them. Incase of successful order shipment application email sender sends email to the user with his new order status;
  - Browse new contacts and answer them. In this case application email sender sends email to the user with the answer;
  - Browse company chat and write messages into it.
- Administrator can:
  - Browse Admin Panel with information about accounts, amployees, administrators, team members, testimonials, gallery images, configured products, orders, order value, new contacts, messages in company chat, product categories, product models, product types and products; 
  - Browse Accounts page and manage the accounts: confirm email, change role or block the account;
  - Browse Orders and ship them. Incase of successful order shipment application email sender sends email to the user with his order status. Delete shipped orders;
  - Browse Contacts and answer them. In this case application email sender sends email to the user with the answer. Delete answered contacts;
  - Browse Products and add new product, edit or delete existing product. The last operation is possible only if the product is not included in shopping cart;
  - Browse Our Team and edit information about the team members - change image Url, position and social media links;
  - Browse Gallery and activate or deactivate gallery images. This changes the appearance of the Gallery image page;
  - Browse Testimonials and activate or deactivate them. This changes the appearance of the Testimonials section in About Us page;
  - Browse company chat and write messages into it. Delete chat history.
- Some more features:
  - Implemented Error handling;
  - Implemented Inmemory cache;
  - Implemented External authentication providers: Google plus and Facebook;
  - Implemented Company chat with SignalR;
  - Implemented Email sender with Sendgrid;
  - Implemented Geolocation with Google Maps;
  - Implemented Data validation;
  - Implemented Repository pattern;
  - Implemented ASP.NET areas for Administrator and Employee roles;
  - Implemented View Components;
  - Implemented Partial views;
  - Implemented 404 (Not Found) page;
  - Implemented Error page for each area;
  - Implemented Loading spinner;
  - Implemented responsive design.

## 🧪 Test Accounts
#### User:
&nbsp;&nbsp;&nbsp;&nbsp;Email: **user@mail.com**  
&nbsp;&nbsp;&nbsp;&nbsp;Password: **123456**  

#### Employee: 
&nbsp;&nbsp;&nbsp;&nbsp;Email: **employee@mail.com**  
&nbsp;&nbsp;&nbsp;&nbsp;Password: **123456** 

#### Administrator: 
&nbsp;&nbsp;&nbsp;&nbsp;Email: **admin@mail.com**  
&nbsp;&nbsp;&nbsp;&nbsp;Password: **123456** 

## :hammer_and_wrench: Technologies and Tools used:

- ASP.NET
- Entity Framework Core
- MS Sql
- JavaScript
- SignalR
- Sendgrid
- xUnit
- Moq
- Bootstrap
- HTML 5
- CSS
- Font Awesome

## :framed_picture: Screenshot - Home Page:

![InteriorDesign-HomePage](https://github.com/mikegsCoder/mikegsCoder.github.io/tree/main/img/InteriorDesign/Homa_Page.jpg)


## :v: Leave a feedback
Give a :star: if you like this app.
Thank you ❤️!

## 📖 License:

This project is licensed under the [MIT License](LICENSE).