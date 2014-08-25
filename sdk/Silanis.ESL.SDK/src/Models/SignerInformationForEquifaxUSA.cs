//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SignerInformationForEquifaxUSA
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("city")]
    public String City
    {
                get; set;
        }
    
		    
    [JsonProperty("dateOfBirth")]
    public Nullable<DateTime> DateOfBirth
    {
                get; set;
        }
    
		    
    [JsonProperty("firstName")]
    public String FirstName
    {
                get; set;
        }
    
		    
    [JsonProperty("homePhoneNumber")]
    public String HomePhoneNumber
    {
                get; set;
        }
    
		    
    [JsonProperty("lastName")]
    public String LastName
    {
                get; set;
        }
    
		    
    [JsonProperty("socialInsuranceNumber")]
    public String SocialInsuranceNumber
    {
                get; set;
        }
    
		    
    [JsonProperty("state")]
    public String State
    {
                get; set;
        }
    
		    
    [JsonProperty("streetAddress")]
    public String StreetAddress
    {
                get; set;
        }
    
		    
    [JsonProperty("zip")]
    public String Zip
    {
                get; set;
        }
    
		
	
	}
}