# _Cut It Again, Sam_

#### _Manage stylist - client list, 6/9/17_

#### By _**Guy Anderson**_

## Description

_An app for the salon owner or employee to track, update, and manage a list of their stylists and clients. The app will display all Stylists that work at the salon. Clicking on the stylists name will bring up a list of all of the clients associated to the stylist. There is functionality to add stylists, and clients. Clients can be updated and deleted._

## Setup/Installation Requirements

* Go to Github repository page.
* Click the "download or clone" button and copy the link
* In your computers terminal type "git clone" & paste the copied link.
* Open SSMS
* Select File > Open > Cut-It-Again-Sam and select MainScrips.sql file.
* CREATE DATABASE [hair_salon]
* Save the file.
* Click Execute.
* Verify that the database has been created and the schema and/or data imported. (good luck!)
* Run dnu restore in terminal
* Run dnx kestrel in terminal
* Open browser, type localhost:5004 for url
* Prepare to be amazed!

## Specs
| Behavior | Input | Output |
|---|---|---|
| Program will have a form entry for stylists | text / Sam | Sam |
| Program will have a form entry to add clients to a stylist | text / Bob | Bob |
| Program will display a list of all current stylists | None | Sam |
| User will be able to click on a stylist to see a list of that stylists clients | Sam | Bob |
| User will be able to remove all Stylists| Delete | You have no employees! |
| User will be able to remove all clients | Delete | You have no clients! |
| User will be able to remove clients 1 at a time | Delete | Success! |
| User will be able to update a clients name (possibly) | Bob | Bobby |

## Known Bugs

_If you try to add a client before you add a stylist the program will error._


## Technologies Used

_C#, Nancy, razor, SQL, SSMS_

### License

Copyright (c) 2017 **_FunGuy Entertainment_**
