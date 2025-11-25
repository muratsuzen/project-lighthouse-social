using System;
using LighthouseSocial.Domain.Common;
using LighthouseSocial.Domain.Countries;
using LighthouseSocial.Domain.ValueObjects;

namespace LighthouseSocial.Domain.Entities;

public class Lighthouse : EntityBase
{
    public string Name { get; private set; }
    public Country Country { get; private set; }
    public Coordinates Locations { get; private set; }
    public List<Photo> Photos { get; } = [];

    protected Lighthouse() { }

    public Lighthouse(string name, Country country, Coordinates locations)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        Locations = locations;
    }
}
