# NetGram-Lab19
[Link to Deployed Site](https://rickstagram.azurewebsites.net/)


This app is a simple Instagram-like image-based social media platform. The home page offers a simple listing of all posts by all users, displaying the posted image, the author, and the title of the post. 

![Screenshot of index page](https://github.com/RickFlinn/Lab19-DotNetGram/blob/master/assets/Screenshot%20(84).png)

Clicking on a post links to a detail view/edit page. This view initially displays information about the post.

![Screenshot of index page](https://github.com/RickFlinn/Lab19-DotNetGram/blob/master/assets/Screenshot%20(85).png)

The user may choose to edit the post, which brings up an edit/create form. Users may input a title, author and description, and upload a file for the post.  Upon saving the post, the user will be redirected back to the detail view for the newly created or updated post. The uploaded image is uploaded to Azure Blob Storage. 

![Screenshot of index page](https://github.com/RickFlinn/Lab19-DotNetGram/blob/master/assets/Screenshot%20(86).png)


### Technologies used
This application is built on the .NET Core framework, EntityFramework with SQLServer, BootStrap, jQuery, and Azure Blob Storage.

