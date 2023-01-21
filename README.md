# Interior-Design

:dart:  My project for the [ASP.NET Advanced](https://softuni.bg/trainings/3854/asp-net-advanced-october-2022) course at SoftUni (October 2022). This is a Web application where you can order furniture, browse gallery with design images and send contact messages to the Interior Desing team.
There are roles for Employee and Administrator inplemented. Implemented application email sender using Sendgrid. Implemented company chat using SignalR. The project was deployed on Azure and now is deployed on SmarterASP.NET.

## 🔗 **Link to the project:**
&nbsp;&nbsp;&nbsp;&nbsp;**[Interior Design](http://mikegscoderasp-001-site1.atempurl.com/)**

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

![InteriorDesign-HomePage](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Home_Page.jpg)

## :framed_picture: Screenshot - Register:

![InteriorDesign-Register](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Register.jpg)

## :framed_picture: Screenshot - Gallery:

![InteriorDesign-Gallery](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Gallery.jpg)

## :framed_picture: Screenshot - Contact Us:

![InteriorDesign-ContactUs](https://travel-destinations-88814.firebaseapp.com/images/interior_design/ContactUs.jpg)

## :framed_picture: Screenshot - Geoloction:

![InteriorDesign-Geolocation](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Map.jpg)

## :framed_picture: Screenshot - Our Team:

![InteriorDesign-OurTeam](https://travel-destinations-88814.firebaseapp.com/images/interior_design/OurTeam.jpg)

## :framed_picture: Screenshot - About Us:

![InteriorDesign-AboutUs](https://travel-destinations-88814.firebaseapp.com/images/interior_design/AboutUs.jpg)

## :framed_picture: Screenshot - Testimonials:

![InteriorDesign-Testimonials](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Testimonials.jpg)

## :framed_picture: Screenshot - Products:

![InteriorDesign-Products](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Products.jpg)

## :framed_picture: Screenshot - Admin Panel:

![InteriorDesign-AdminPanel](https://travel-destinations-88814.firebaseapp.com/images/interior_design/AdminPanel.jpg)

## :framed_picture: Screenshot - Accounts:

![InteriorDesign-Accounts](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Accounts.jpg)

## :framed_picture: Screenshot - Admin Gallery:

![InteriorDesign-AdminGallery](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Admin_Gallery.jpg)

## :framed_picture: Screenshot - Admin Testimonials:

![InteriorDesign-AdminTestimonials](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Admin_Testimonials.jpg)

## :framed_picture: Screenshot - Company Chat:

![InteriorDesign-CompanyChat](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Company_Chat.jpg)

## :framed_picture: Screenshot - 404 page:

![InteriorDesign-404](https://travel-destinations-88814.firebaseapp.com/images/interior_design/404.jpg)

## :framed_picture: Screenshot - Access Denied:

![InteriorDesign-AccessDenied](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Access_Denied.jpg)

## :framed_picture: Screenshot - Error Handling:

![InteriorDesign-ErrorHandling](https://travel-destinations-88814.firebaseapp.com/images/interior_design/Application_Error.jpg)

## :framed_picture: Screenshot - Database Diagram:

![InteriorDesign-DatabaseDiagram](https://travel-destinations-88814.firebaseapp.com/images/interior_design/DB_Diagram.jpg)

## :v: Leave a feedback
Give a :star: if you like this app.
Thank you ❤️!

## 📖 License:

This project is licensed under the [MIT License](LICENSE).