# Assignment 3: Gui Plan

The plan of attack.

## Components/views

#### Login (Done?)

Can be accessed without being authorized.
Will need to save credentials to local-storage after login is succesful and route to some **Home Component**?

#### NavBar (Done? / Needs population still ofc)

Should just be rendered in the App.vue as that will show it on all sites
Needs to be populated depending on user-role
Following might be showed

-   Login/Logout
-   Home
-   Create Model (manager)
-   Create Manager (managers)

#### HomeComponent

Contains two subcomponents, and will choose which one to render depending on user-role
If not loggedin - show login-component

##### HomeManager (Christoffer)

Shows a list of all jobs. If a job is clicked go to ManagerJob/{:id}
Also button to add job. Will route to ModelJob

##### HomeModel (Lau)

Shows a list of jobs for a specific model.

Show list of model jobs
If a list of jobs is clicked it routes to that specific ModelJob{:id}

#### ManagerJob

Create a new job

#### ManagerJobWithId/{:id}

Shows a list of all models on that job, and a list of all models not on that job
Models on the job will have a "Remove" button, and models not on the job will have a "Add" button.

#### ModelJob/{:id}

Can add an expense to that specific job

#### Create Manager

Simpel form til at lave en manager

#### Create Model

Simpel form til at lave en model

## Roles

-   Manager
-   Model
