# What was done? #

- Created a microservice in the API model that provides the solution to the problem reported through a REST webservice;
- Was used ASP.NET Core;
- To improve usability, the Swagger tool was implemented in the API;
- Design Patterns like DDD, CQRS were used to better organize the code layers.

## How to test? ##

After running the application, the address "localhost:5000/swagger/" will be available to validate the solution.
It is also possible to trigger a POST request directly, as requested below:


```
http://localhost:5000/ParseTheParcels/Api/Shipping/Calculate

{
  "dimensions": {
    "length": 180,
    "breadth": 265,
    "height": 148
  },
  "weight": 24
}