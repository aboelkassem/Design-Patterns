## Suggestions for Object Orientated Design
Whenever writing code in an object orientated language, sticking to the following list of suggestions will make your code amenable to changes with the least effort.
* <b>Separate</b> out parts of code that vary or change from those that remain the same.
* Always code to <b>an interface</b> and not against a concrete implementation.
* <b>Encapsulate</b> behaviors as much as possible.
* Favor composition over inheritance. Inheritance can result in explosion of classes and also sometimes the base class is fitted with new functionality that isn't applicable to some of its derived classes.
* Interacting components within a system <b>should be as loosely coupled as possible.</b>
* Ideally, class design should <b>inhibit modification and encourage extension.</b>
* Using patterns in your day to day work, allows exchanging entire implementation concepts with other developers via shared pattern vocabulary.

## Why Patterns ?
The answer is we <b>don't want to reinvent the wheel!</b> Problems that occur frequently enough in tech life usually have <b>well-defined solutions, which are flexible, modular and more understandable.</b> These solutions when abstracted away from the tactical details become design patterns.


# Software Design Patterns
Is a general solutions to common software design problems, each pattern is like a blueprint or guidelines on how to solve a particular design problem in your code.

# Types Of Design Patterns
These are 3 categories used by <a href="https://en.wikipedia.org/wiki/GOF">GoF</a> in their seminal work on design patterns
- Creational Patterns
- Structural Patterns
- Behavioral Patterns

## Creational Patterns
Creational design patterns relate to how objects are created or constructed from classes to increase flexibility and reuse of existing code. The creational design pattern come with powerful suggestions on how best to encapsulate the object creation process in a program.
- Singleton Pattern
- Builder Pattern
- Prototype Pattern
- Factory Method Pattern
- Abstract Factory Pattern

### Singleton Pattern
As the name suggests is <b>Only create one instance of a class,</b> There are several examples where only a single instance of a class should exist. <b>Caches, App Settings, thread pools, registries, Database Context, Logging </b>are examples of objects that should only have a single instance.
* <b>Real world example</b>
> There can only be one president of a country at a time. The same president has to be brought to action, whenever duty calls. President here is singleton.
How do we ensure that only one object ever gets created?  The answer is to <b>make the constructor private</b> of the class we intend to define as singleton. That way, only the members of the class can access the private constructor and no one else
* <b>Class Diagram</b>

#### Problem of using Multithreading in Singleton Pattern
As soon as multiple threads start using the class, there's a potential that multiple objects get created, so if the code run in parallel it will create two instances seperately from the class and it's against Singleton rule.

<b>There are two ways to fix this problem</b>
- Is to add lock keyword to GetInstance() method to make sure that is object is locked until the first operation finished it's implementation
- By double-checked locking
<b>Example</b>
```Csharp
public class Counter
    {
        // The sole instance of the class
        private static Counter instance = null;

        public int count = 0;
        // just for locking this object to solve multi-threading problem
        private static object lockObj = new object();

        // Make the constructor private so its only accessible to members of the class.
        private Counter(){}

        // Create a static method for object creation
        public static Counter GetInstance()
        {
            // Only instantiate the object when needed, to save memory recourses
            // Lazy Initialization
            // Double-checked locking
            if (instance == null)
            {
                lock(lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Counter();
                    }
                }
            }

            return instance;
        }

        public void AddOne(){count++;}
    }
```

## Structural Patterns
Structural patterns are concerned with the composition or relationships of classes i.e. how the classes are made up or constructed or they help in answering "How to build a software component?", in other words how the entities can use each other.
- Proxy Pattern
- Decorator Pattern
- Adapter Pattern
- Facade Pattern
- Bridge Pattern
- Composite Pattern
- Flyweight Pattern

## Behavioral Patterns
Behavioral design patterns dictate the interaction and assignment of responsibilities between the objects, Or in other words, they assist in answering "How to run a behavior in software component?"
- Observer Pattern
- Visitor Pattern
- Strategy Pattern
- Interpreter Pattern
- Template Pattern
- Chain of Responsibility Pattern
- Command Pattern
- Iterator Pattern
- Mediator Pattern
- Memento Pattern
- State Pattern
