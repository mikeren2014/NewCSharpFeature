using System;
using System.Collections.Generic;

namespace NullableProject
{
    // #nullable enable
    // #nullable restore
    // <Nullable>enable</Nullable>
    public class Canvas
    {
        // Initialized in ctor
        public string Name { get; set; }

        // Initialized when declaration
        public IEnumerable<Layer> Layers { get; set; } = new List<Layer>();

        // Value Type
        public int Height { get; set; }

        // Nullable referenceType ?
        public IEnumerable<Group>? Groups { get; set; }

        public Canvas(string name)
        {
            Name = name;
        }

        public void SetName(Layer? layer)
        {
            // Nullforgiving operator !
            Name = layer!.Name;

            var newLayer = layer;

        }
    }

    public class Layer
    {
        public string Name { get; set; } = "Layer";
                
    }

    public class Group
    { }
}
