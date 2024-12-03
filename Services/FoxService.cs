using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;

public class FoxService : IFoxService
{
    private readonly IFoxesRepository _foxesRepository;
    private readonly ILogger<FoxService> _logger;

    public FoxService(IFoxesRepository foxesRepository, ILogger<FoxService> logger)
    {
        _foxesRepository = foxesRepository;
        _logger = logger;
    }

    public IEnumerable<Fox> GetAll()
    {
        return _foxesRepository.GetAll()
                .OrderByDescending(x => x.Loves)
                .ThenBy(x => x.Hates);
    }

    public Fox Get(int id)
    {
        var fox = _foxesRepository.Get(id);
        if (fox == null)
        {
            _logger.LogWarning($"Fox with ID {id} not found.");
            throw new KeyNotFoundException($"Fox with ID {id} not found.");
        }
        return fox;
    }

    public void Add(Fox fox)
    {
        fox.Loves = 0;
        fox.Hates = 0;
        _foxesRepository.Add(fox);
    }
    public void Update(int id) {
        Fox f = Get(id);
        if(f == null) {
            _logger.LogWarning($"Fox with ID {id} not found.");
            throw new KeyNotFoundException($"Fox with ID {id} not found.");
        }
        _foxesRepository.Update(id, f);
    }

    public void Love(int id)
    {
        var fox = Get(id);
        if (fox == null)
        {
            _logger.LogWarning($"Fox with ID {id} not found.");
            throw new KeyNotFoundException($"Fox with ID {id} not found.");
        }
        fox.Loves++;
        _foxesRepository.UpdateLoveHate(fox);
    }

    public void Hate(int id)
    {
        var fox = Get(id);
        if (fox == null)
        {
            _logger.LogWarning($"Fox with ID {id} not found.");
            throw new KeyNotFoundException($"Fox with ID {id} not found.");
        }
        fox.Hates++;
        _foxesRepository.UpdateLoveHate(fox);
    }
}