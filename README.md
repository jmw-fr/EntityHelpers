# EntityHelpers
Helper library for EntityFramework 6.1.3

This library adds some extensions to EntityFramework to help developers.

Extensions available :
- DbEntityValidationException.LogMessage().

## DbEntityValidationException.LogMessage()

Returns a formatted message of the Validation Exception :

```
using Jmw.EntityHelpers;

...

      catch (DbEntityValidationException ex)
      {
         // the variable will containt a readable of the validation errors.
         string message = ex.LogMessage();
      }

```
