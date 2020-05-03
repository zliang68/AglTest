# AGL Programming challenge

A json web service has been set up at the url: http://agl-developer-test.azurewebsites.net/people.json
You need to write some code to consume the json and output a list of all the cats in alphabetical order under a heading of the gender of their owner.
```
Example:
Male

    Angel
    Molly
    Tigger

Female

    Gizmo
    Jasper
```

## Development Notes

This application is developed using
* Asp.NET Core 3.1 for Web Api service
* XUnit is used for unit testing
* Angular 9 for UI in browser

## Application file structure

Projects in Visual Studio Solution:
* WebAppCore - WebApi server application
* TestLibrary - A library of constants, models and services 
* UnitTests - Unit tests for this application

Angular project 
* agl-test-ng - default to use service of local WebApi application
It also has implimentation of getting data directly from 
http://agl-developer-test.azurewebsites.net/people.json

### Configuration

AGL test url is added to Appsetting.json
```
  "PeopleServiceUrl": "http://agl-developer-test.azurewebsites.net/people.json"
```

## How to run this application

### WebApi appliction
* Open the solution in Visual Studio 2019,
* Restore referenced packages 
* press F5 to run the server application

### Angular SPA 
* Open a Command Prompt window;
* Change directory to 'al-test-ng' folder, run following command: 
```
  npm install
  ng serve
```

## Author

* David Liang 0405312838
