using Microsoft.AspNetCore.Mvc;
using CustomerService;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{ 
    private static List<Customer> _customers = new List<Customer>() { 
     new Customer() {  
         Id = 1, 
         Name = "International Bicycles A/S", 
         Address1 = "Nydamsvej 8", 
         Address2 = null, 
         PostalCode = 8362, 
         City = "Hørning", 
         TaxNumber = "DK-75627732", 
         ContactName = "Dennis Jørgensen" 
     } 
 };

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{customerId}", Name =
"GetCustomerById")]
 public Customer Get(int customerId) 
 {  
     _logger.LogInformation("Method 'Get' called at {DT}",  
         DateTime.UtcNow.ToLongTimeString()); 
     return _customers.Where(c => c.Id == customerId).First(); 
 
    
 } 
 [HttpPost(Name =
"PostCustomer")]
 public void Post([FromBody]Customer customer) 
 {      
     try{
  _logger.LogInformation("Method 'Get' called at {DT}",  
         DateTime.UtcNow.ToLongTimeString()); 
      _customers.Add(customer);
      
     
     }
    catch (Exception ex) {
        
        
         _logger.LogError(ex.Message,"oopsie at post");
         throw ex;
        
       
       
         
       
    }
      
 } 
    }

