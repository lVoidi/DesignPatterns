
# Structural Design Patterns
Structural design patterns are design patterns that ease the design by identifying a simple way to realize relationships between entities. These patterns focus on how classes and objects can be composed to form larger structures.

## Common Structural Design Patterns
- **Adapter Pattern**

    - Converts the interface of a class into another interface that a client expects.
    - Allows classes to work together that couldn't otherwise because of incompatible interfaces.
- **Bridge Pattern**

    - Decouples an abstraction from its implementation so that the two can vary independently.
    - Useful when both the class and what it does vary often.

- **Composite Pattern**
    - Composes objects into tree structures to represent part-whole hierarchies.
    - Allows clients to treat individual objects and compositions of objects uniformly.

- **Decorator Pattern**
    - Adds additional responsibilities to an object dynamically.
    - Provides a flexible alternative to subclassing for extending functionality.

- **Facade Pattern**
    - Provides a unified interface to a set of interfaces in a subsystem.
    - Defines a higher-level interface that makes the subsystem easier to use.

- **Flyweight Pattern**

    - Reduces the cost of creating and manipulating a large number of similar objects.
    - Shares objects to support large numbers of fine-grained objects efficiently.

- **Proxy Pattern**
    - Provides a surrogate or placeholder for another object to control access to it.
    - Useful for lazy initialization, access control, logging, etc.
## Benefits of Structural Design Patterns
- **Flexibility**: They promote flexible and reusable code by allowing objects to be composed in various ways.
- **Scalability**: They help in managing large and complex structures by breaking them into smaller, manageable pieces.
- **Maintainability**: They enhance code maintainability by promoting clear and understandable relationships between entities.