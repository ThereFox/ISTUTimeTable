using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Interfaces;
using Src.Core.App.Interfaces;

namespace App.Analitics;

public class UnpassingStatistics
{
    private readonly IUserAndGroupRepository _userRepository;
    private readonly IUnpassingRepository _unpassingSource;

    public void GetStatistickByUser(int userId)
    {
        var user = _userRepository.GetUser(userId);
        var unpasings = _unpassingSource.GetAllUnpassingByUser(user);
        

    }


}
