using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.ResourceParameters
{

    /* ***** This is used as an Action parameter. Meaning that the stuff the caller of the api sends (http requestl be stuffed in 
             the properties here. Of course only for those actions where this is specified as a parameter */
    public class AuthorsResourceParameters
    {
        /* ************** stuff received from http request */
        
            // For filtering
                public string MainCategory { get; set; }                
            
            // For searching
                public string SearchQuery { get; set; }                 

            // For Pagination
                public int PageNumber { get; set; } = 1;

                private int _pageSize = 10;             // If the caller of the api does not send PageSize 
                public int PageSize
                {
                    get => _pageSize;

                    /******************************************* I consider this as POOR-MAN's CUSTOM MODEL BINDING :)   ******* */
                    set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }

                public string OrderBy { get; set; } = "Name";   // If the caller does not send OrderBy then we use a default
            
            // For projection
                public string Fields { get; set; }          
         /* ************** stuff received from http request */

        
        /* It is for stuff like this that I consider this a DTO+   ************************** */
        const int maxPageSize = 20;                     // For protection 
    }
}
