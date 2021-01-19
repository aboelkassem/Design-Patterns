### Suggestions for [Object Oriented Design](https://github.com/aboelkassem/Design-Patterns/tree/main/OOD)
Whenever writing code in an object orientated language, sticking to the following list of suggestions will make your code amenable to changes with the least effort. You can learn Object-Oriented Design and Analysis from this **[Link](https://github.com/aboelkassem/Design-Patterns/tree/main/OOD)**

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
It is a **general solutions** to common software design **problems**, each pattern is like a blueprint or guidelines on how to solve a particular design problem in your code.
**Design patterns** are a bit more conceptual, It is **knowledge** that you can apply within your software design to guide its structure, and make it flexible and reusable.
**Design patterns** help to create a **design vocabulary,** rather than having to explain the details of design solution over and over again to someone, you just use a suggestive word to describe it which making easier for developers to communicate
You choose your **pattern** based on the **problem space**

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
How do we ensure that only one object ever gets created?  The answer is to <b>make the constructor private (lazy construction)</b> of the class we intend to define as singleton. That way, only the members of the class can access the private constructor and no one else
**lazy creation** means that the object is not created until it is truly **needed**. This is helpful, especially if the object is large. As the object is not created until the “getInstance” method is called, the program is more efficient.

* <b>Class Diagram</b>

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/singleton-uml.jpg" width="500" hight="500"/>
</p>

#### Problem of using Multithreading in Singleton Pattern
As soon as multiple threads start using the class, there's a potential that multiple objects get created, so if the code run in parallel it will create two instances seperately from the class and it's against Singleton rule.

<b>There are two ways to fix this problem</b>
- Is to add lock keyword to GetInstance() method to make sure that is object is locked until the first operation finished it's implementation
- By double-checked locking

**Example 1**
```csharp
class AppSettings
{
    // the class variable is null if no instance is instantiated
    private static AppSettings Instance = null;
    private AppSettings() {}

    public static AppSettings GetInstance()
    {
        if (Instance == null)
        {
            Instance = new AppSettings();
        }
        return Instance;
    }
}
```

**Example 2**
```csharp
public class Counter
{
    // The sole instance of the class
    // the class variable is null if no instance is instantiated    
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

class Program
{
    static void Main(string[] args)
    {
        Counter counter1 = Counter.GetInstance();
        Counter counter2 = Counter.GetInstance();
        counter1.AddOne();
        counter2.AddOne();

        Console.WriteLine("counter 1:" + counter1.count.ToString());
        Console.WriteLine("counter 2:" + counter2.count.ToString());
        Console.WriteLine();

        counter1.AddOne();
        Console.WriteLine("counter 1:" + counter1.count.ToString());
        Console.WriteLine("counter 2:" + counter2.count.ToString());
    }
}
```
### Simple Factory objects

Just like the factory in the real world to create goods, in software factory pattern create objects.

**Problem example**

> Imagine a situation where you have a software that implements an online store that sells knives, and you sell only two knives, steak knives and chef’s knives, after that the store is successful and adds more knife types to sell, so the code of method to order knife will be like this with a lot of conditions

```csharp
Knife orderKnife(string knifeType) 
{
	Knife knife;
	
	// Create knife object- concrete instantiation
	if (knifeType.equals("steak")){
		knife = new SteakKnife();
	} else if (knifeType.equals("chefs")){
		knife = new ChefsKnife();
	}else if (knifeType.equals("bread")){
		knife = new BreadKnife();
	}else if (knifeType.equals("paring")){
		knife = new ParingKnife();
	}
	
	// prepare the Knife
	knife.sharpen();
	knife.polish();
	knife.package();

	return knife;
}
```

To solve this problem we use Factory Method Pattern by creating a **factory** object whose role is to create **product** objects of particular types, so we will move the code responsible for creating objects into a **method** in the factory class like this

```csharp
public class KnifeFactory {
	public Knife createKnife(String knifeType) {
		Knife knife = null;

		// create Knife object
		If (knifeType.equals("steak")) {
			knife = new SteakKnife();
		} else if (knifeType.equals("chefs")) {
			knife = new ChefsKnife();
		}else if (knifeType.equals("bread")){
			knife = new BreadKnife();
		}else if (knifeType.equals("paring")){
			knife = new ParingKnife();
		}

		return knife;
	}
}
```

So the above code of **orderKnife** which will be the **client** to use **KnifeFactory** will be like this

```csharp
public class KnifeStore {
	private KnifeFactory factory;

	// require a KnifeFactory object to be passed to this constructor:
	Public KnifeStore(KnifeFactory factory) {
		this.factory = factory;
	}

	Public Knife orderKnife(String knifeType) {
		Knife knife;

		// use the create method in the factory
		knife = factory.createKnife(knifeType);

		// prepare the Knife
		knife.sharpen();
		knife.polish();
		knife.package();

		return knife;
	}
}
```

**The Benefits of Factory Objects**

- Other clients can use **KnifeFactory** to create knives for other purpose not only **orderKnife** method, meaning if there are multiple clients that want to instantiate the same classes, then by using a Factory object, you have cut out redundant code and made the software easier to modify
- You can simply add knife types to your **KnifeFactory** without modifying the client code. which allows the developers to **make changes** to the concrete instantiation without touching the **client method**
- Factories allow client code to operate on **generalizations**. This is known as "**coding to an interface, not an implementation**". The client method does not need to name concrete knife classes, and now deals with a Knife “**generalization**”. As long as the client code receives the object it expects, it can satisfy its responsibilities without worrying about the details of object creation.

### Factory Method Pattern

It handles the creation of specific **types of objects** in a different way. **Factory object** to create the objects, **Factory Method** uses a separate "method" in the same class to create the objects

Define an **interface** for creating an object, but let subclasses decide which class to instantiate, which mean creating an object without exposing the creation logic to the client and refer to newly created object using a common interface.

**A Factory Method** is responsible for creating the subclasses on it's way, This is known as **letting the  subclasses decide** how objects are made. like BudgetChefsKnife and BudgetSteakKnife

**Steps to apply factory method pattern**

- define the **class** as **abstract** so it cannot be instantiated
- define the **method** to create the objects as **abstract** to be defined by the **subclasses** which called **factory method**

**Real world example**

> Consider an example of using multiple database servers like SQL Server and Oracle. If you are developing an application using SQL Server database as backend, but in future need to change backend database to oracle, you will need to modify all your code, if you haven’t written your code following factory design pattern.

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/FactoryMethodUML.png" width="500" hight="500"/>
</p>

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/FactoryMethodUML-ex.png" width="500" hight="500"/>
</p>

**For Example** 

```csharp
public abstract class KnifeStore {
	public Knife orderKnife(String knifeType) {
		Knife knife;
		// now creating a knife is a method in the
		class knife = createKnife(knifeType);

		knife.sharpen();
		knife.polish();
		knife.package();

		return knife;
	}
	abstract Knife createKnife(String type);
}
```

in above example, Now When a subclass is defined, it “must” define this **createKnife** method like this

```csharp
public BudgetKnifeStore: KnifeStore {
	//up to any subclass of KnifeStore to define this method
	Knife createKnife(String knifeTYpe) {
		if (knifeType.equals(“steak”)) {
			return new BudgetSteakKnife();
		} else if (knifeType.equals(“chefs”)) {
			return new BudgetChefsKnife();
		}
		//.. more types
		else return null;
	}
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
