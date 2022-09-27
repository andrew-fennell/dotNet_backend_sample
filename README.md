# Endava Technical Interview

## Project Setup
- Fork the repository and clone it to your local machine. For documentation on how to do this, please visit: https://docs.github.com/en/get-started/quickstart/fork-a-repo
- Open the project locally
- Create a new branch in the newly forked repo using the naming convention **yourFirstName_yourLastName**. This is where your work should be saved.
- Run the project from the LvvlStarterNetApi.Api folder using `dotnet run` 
- The application will start on [http://localhost:5000](http://localhost:5000)

## Existing State
This is a simple REST application for serving a blog. <br>
It uses dotnet core 5.0, C#, and data is stored in a Mongo database.

Currently the application has 2 endpoints:
    
    1) Get all blog posts - Get at api/blog
    2) Get blog post by Id - Get at api/blog{id}
    3) To add a blog post - Post at api/blog
    4) Delete a blog post - Delete at api/blog/id       
## Task
Your task is to add a commenting feature.

You should add two new endpoints.

    1) Post at api/blog{1}/comment - which should create a new comment for a post with passed {id}
    
    2) Get at api/blog{1}/comment - which should return all comments for a post with passed {id}

Under the resources folder are example json files for both a Blog and a Comment.

Feel free to modify existing files or create new files.  You may add new dependencies if you choose. Please follow the conventions in place throughout the project.


## Connecting to the Database

For this project, a MongoDB will be needed in order to store all your data.

In order to startup the DB. Download MongoDB and MongoDB Compass to your local setup.

    - Once installed. On your local go to where you would like to store your data.
    - Create a folder called "data/db"
    - Once created, run "mongodb --dbpath $PATH/data/db" where $PATH is the local route to the db folder.
    - This should startup your local MongoDB. Connect to your local MongoDB via MongoDB Compass with is connection string. 

        mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false
        
    - From there create collections and documents as you see fit.

## Resources
You may use any internet sources to aid your implementation.<br><br>
Below are a few links to documentation that may be helpful:<br><br>

dotnet - https://docs.microsoft.com/en-us/dotnet/?WT.mc_id=dotnet-35129-website

Mongo - https://docs.mongodb.com/guides/server/install/ : https://docs.mongodb.com/guides/

## Submitting Your Work (IMPORTANT)
When you are finished, create a Pull Request in Github for the forked repository. This Pull Request should compare your created branch to the **main** branch. Email the link to your Pull Request to nicole.niemczycki@endava.com **at least 24 hours prior to your technical interview**

Again, please make sure your Pull Request is comparing the new branch you created on your forked repo to the *main* branch on your forked repo. The initial repository you forked off of should NOT be referenced.
