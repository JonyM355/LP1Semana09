```mermaid
classDiagram
    class Animal{
        + Sound() string
    }

    class Cat{
        + Sound() string
    }

    class Dog{
        + Sound() string
    }

    class Bat{
        + Sound() string
    }

    Animal <|-- Cat
    Animal <|-- Dog
    Animal <|-- Bat
```