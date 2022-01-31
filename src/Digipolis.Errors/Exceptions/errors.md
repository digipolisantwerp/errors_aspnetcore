# Error types

*This file offers a default listing of the errors types and can be used as
reference value for the Error.Type property. 
Copy this file to a appropriate location for your API and change or extent this content to suite the needs of your API.*

Error              | HTTP status code   |Description
------------------ | -----| --------------------------------------------------------
UNVALI001          | 400  | The parameters used with the request are invalid
UNAUTH001          | 401  | Unauthorized to access the requested resource 
FORBID001          | 403  | Access to the requested resource is forbidden 
TMREQU001          | 429  | Too many requests (API gateway rate limiting)
NFOUND001          | 404  | Requested resource hasn't been found
GTWAY001           | 502  | Bad gateway
GTWAY002           | 504  | Gateway sent time out during request 