using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HRMS.Dal;
using HRMS.Dal.Contracts.Entities;

namespace HRMS.API.Controllers;

[Route("api/userroles")]
[ApiController]
public class UserRolesController : ControllerBase
{
    //WARNING: DO NOT USE CODE BELOW. THIS IS TEST CODE
    private readonly HrmsDbContext _dbContext;

    public UserRolesController(HrmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IList<UserRole> GetAllRoles()
    {
        return _dbContext.UserRoles.ToList();
    }
}