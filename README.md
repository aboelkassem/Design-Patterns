## Table of Contents
- [Software Design Patterns](#software-design-patterns)
- [Types Of Design Patterns](#types-of-design-patterns)
  - [Creational Patterns](#creational-patterns)
    - [Singleton Pattern](#singleton-pattern)
      - [Problem of using Multithreading in Singleton Pattern](#problem-of-using-multithreading-in-singleton-pattern)
    - [Simple Factory objects](#simple-factory-objects)
    - [Factory Method Pattern](#factory-method-pattern)
  - [Structural Patterns](#structural-patterns)
    - [Facade Pattern](#facade-pattern)
    - [Adapter Pattern](#adapter-pattern)
    - [Composite Pattern](#composite-pattern)
    - [Proxy Pattern](#proxy-pattern)
    - [Decorator Pattern](#decorator-pattern)
  - [Behavioral Patterns](#behavioral-patterns)
    - [Template Method Pattern](#template-method-pattern)
    - [Chain Of Responsibility Pattern](#chain-of-responsibility-pattern)
    - [State Pattern](#state-pattern)
    - [Command Pattern](#command-pattern)
    - [Mediator Pattern](#mediator-pattern)
    - [Observer pattern](#observer-pattern)
  
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

- Other clients can use `KnifeFactory` to create knives for other purpose not only `orderKnife` method, meaning if there are multiple clients that want to instantiate the same classes, then by using a Factory object, you have cut out redundant code and made the software easier to modify
- You can simply add knife types to your `KnifeFactory` without modifying the client code. which allows the developers to **make changes** to the concrete instantiation without touching the **client method**
- Factories allow client code to operate on **generalizations**. This is known as "**coding to an interface, not an implementation**". The client method does not need to name concrete knife classes, and now deals with a Knife “**generalization**”. As long as the client code receives the object it expects, it can satisfy its responsibilities without worrying about the details of object creation.

### Factory Method Pattern

It handles the creation of specific **types of objects** in a different way. **Factory object** to create the objects, **Factory Method** uses a separate "method" in the same class to create the objects

Define an **interface** for creating an object, but let subclasses decide which class to instantiate, which mean creating an object without exposing the creation logic to the client and refer to newly created object using a common interface.

**A Factory Method** is responsible for creating the subclasses on it's way, This is known as **letting the  subclasses decide** how objects are made. like `BudgetChefsKnife` and `BudgetSteakKnife`

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
	public Knife orderKnife(string knifeType) {
		Knife knife;
		// now creating a knife is a method in the
		class knife = createKnife(knifeType);

		knife.sharpen();
		knife.polish();
		knife.package();

		return knife;
	}
	abstract Knife createKnife(string type);
}
```

in above example, Now When a subclass is defined, it “must” define this **createKnife** method like this

```csharp
public BudgetKnifeStore: KnifeStore {
	//up to any subclass of KnifeStore to define this method
	Knife createKnife(string knifeTYpe) {
		if (knifeType.Equals("steak")) {
			return new BudgetSteakKnife();
		} else if (knifeType.Equals("chefs")) {
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

### Facade Pattern

This pattern provide a single simplified **interface** for client classes to interact with subsystem, A facade literally means **the front of a building** or an outward appearance to **hide a less pleasant reality**. The facade pattern essentially does the same job as the definition of the word facade. Its purpose is to **hide the complexity of an interface** or a subsystem. Facade pattern does not actually add more functionality. It simply acts as a point of **entry** into your subsystem

**Facade Pattern** is a **wrapper class** that **encapsulate** a subsystem in order to **hide subsystem's complexity.**

**Real world example**

> How do you turn on the computer? "Hit the power button" you say! That is what you believe because you are using a simple interface that computer provides on the outside, internally it has to do a lot of stuff to make it happen. This simple interface to the complex subsystem is a facade.

**Problem example**

> The following diagram shows the classes for simple banking system without facade, Customer class would contains instances of Chequing, Saving and Investment classes, This means Customer must instantiating each of these classes and know all their different attributes and methods

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/facade-1.png" width="600" hight="600"/>
</p>

To Solve this problem we introduce the **BankService** Class to act as a **facade class** for chequing, saving and investment classes to deal with any other complexities of financial management instead the customer himself, A facade class can be used to wrap all the **interfaces and classes** for a subsystem not only on interface

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/facade-2.png" width="600" hight="600"/>
</p>

**Steps to apply Facade Design Pattern**

- **Step1:** Design the interface

```csharp
public interface IAccount
{
    public void deposit(decimal amount);
    public void withdraw(decimal amount);
		public void transfer(IAccount toAccount, decimal amount);
    public int getAccountNumber();
}
```

- **Step2**: Implement the interface with one or more classes

```csharp
public class Chequing : IAccount {.....}
public class Saving : IAccount {.....}
public class Investment : IAccount {.....}
```

- **Step3**: Create the facade class and wrap the classes that implement the interface

```csharp
public class BankService
{
    private Dictionary<int, IAccount> BankAccounts;

    public BankService()
    {
        this.BankAccounts = new Dictionary<int, IAccount>();
    }

    public int createNewAccount(string type, decimal initAmount)
    {
        IAccount newAccount = null;
        switch (type)
        {
            case "chequing":
                newAccount = new Chequing(initAmount);
                break;
            case "saving":
                newAccount = new Saving(initAmount);
                break;
            case "investment":
                newAccount = new Investment(initAmount);
                break;
            default:
                Console.WriteLine("Invalid account type");
                break;
        }

        if (newAccount != null)
        {
            this.BankAccounts.Add(newAccount.getAccountNumber(), newAccount);
            return newAccount.getAccountNumber();
        }
        else
        {
            return -1;
        }
    }

    public void transferMoney(int to, int from, decimal amount)
    {
        IAccount toAccount = this.BankAccounts[to];
        IAccount fromAccount = this.BankAccounts[from];
        fromAccount.transfer(toAccount, amount);
    }
}
```

- **Step4:** Use the facade class to access the subsystem/client class

```csharp
public class Customer
{
    public static void Main(string[] args)
    {
        BankService bankService = new BankService();

        int mySaving = bankService.createNewAccount("saving", new decimal(500.00));
        int myInvestment = bankService.createNewAccount("investment", new decimal(1000.00));

        bankService.transferMoney(mySaving, myInvestment, new decimal(300.00));
    }
}
```

**Facade Pattern** removes the need for client classes to manage a subsystem on their own, resulting in less coupling between the subsystem and the client classes

**Facade Pattern** handles instantiation of the appropriate class within the subsystem

**Facade Pattern** provides client classes with a simplified interface for the subsystem

### Adapter Pattern

As name suggest, an adapter is a device that is used to connect pieces of equipment that cannot be connected directly. **Software system** also have the same **compatibility** issue with **interfaces,** in other word the output of one system may **not conform** to the expected input of another system, you will find this problem in pre-existing system need to incorporate **third-party** libraries or connect to other systems.

**Real World example**

> Consider that you have some pictures in your memory card and you need to transfer them to your computer. In order to transfer them you need some kind of adapter that is compatible with your computer ports so that you can attach memory card to your computer. In this case card reader is an adapter. Another example would be the famous power adapter; a three legged plug can't be connected to a two pronged outlet, it needs to use a power adapter that makes it compatible with the two pronged outlet. Yet another example would be a translator translating words spoken by one person to another

**The Adapter design pattern** facilitates communication between two existing systems by providing a **compatible interface.** Another definition is allowing incompatible classes to work together by **converting the interface of one class into another expected by the clients.** Examples like **SMS Clients, Database Adapter**

**Class Diagram and The Parts of Adapter Pattern**

- **Client**: the class who wants to use a third-party library or external system
- **Adaptee**: the class in the third-party library or external system to be used
- **Adapter**: the class sites between client and the adaptee, it implement a target interface to conforms what the client is expecting to see.
- **Target Interface**: the interface which the client will use.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/adapter-diagram-1.png" width="400" hight="400"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/adapter-diagram-2.png" width="400" hight="400"/>
</p>

The above diagram shows that the **client** sends a request to the **adapter** using the **target interface**, The adapter will then translate the request into a message that the **adaptee** will understand.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/adapter-diagram-3.png" width="500" hight="500"/>
</p>

**The Steps to implement the adapter pattern with example of talking WebClient to WebService**

example is the WebClient want to send **any object** but the WebService only accept a **JSON object**

- **Step1:** Design the target interface

```csharp
public interface IWebRequester
{
    public int request(object request);
}
```

- **Step2**: Implement the target interface with the adapter class

```csharp
public class WebAdapter : IWebRequester
{
    private WebService service;

    public void connect(WebService currentService)
    {
        this.service = currentService;
    }

    public int request(object request)
    {
        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request);
        var resposne = service.request(jsonString);
        if (resposne != null)
            return 200; // OK status code
        return 500; // raise error status code
    }
}
```

- **Step3**: Send the request from the client to the adapter using the target interface

```csharp
public class WebClient
{
    private IWebRequester webRequester;

    public WebClient(IWebRequester webRequester)
    {
        this.webRequester = webRequester;
    }

    public void getInfo()
    {
        object obj = new object();
        int status = webRequester.request(obj);

        if (status == 200)
            Console.WriteLine("OK");
        else
            Console.WriteLine("Not OK");
    }
}
```

- **In the main program**, the Web Adapter, the Web Service, and the Web Client needs to be instantiated, The **WebClient** deals with the **adapter** through the **WebRequester** interface to send a request. The WebClient should not need to know anything about the **WebService**, such as its need for JSON objects.

```csharp
class Program
{
    static void Main(string[] args)
    {
        string webHost = "https://google.com";
        WebService service = new WebService(webHost);
        WebAdapter adapter = new WebAdapter();

        adapter.connect(service);

        WebClient client = new WebClient(adapter);
        client.getInfo();
    }
}
```

**Why we just change one interface or the both to be able to talk to each other?**

This is not always feasible, especially if the other interface is from **a third-party library** or external system. Changing your system to match the other system is not always a solution either, because an update by the vendors to the outside systems may break part of our system, Also we don't change **our system interface** because if there are sub system using it.

### Composite Pattern

**Composite Pattern** is meant to compose objects into tree structures to represent part-whole hierarchies, it lets clients treat individual objects and compositions of objects uniformly. For example Composable DTOs.

A **composite design pattern** is meant to achieve two goals:

- To compose nested structures of objects
- To deal with the classes for theses objects uniformly

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/composite-diagram-1.png" width="400" hight="400"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/composite-diagram-3.png" width="400" hight="100"/>
</p>

In this design, a component interface serves as the supertype for a set of classes. Using **polymorphism**, all implementing classes conform to the same interface, allowing them to be dealt with uniformly.

**The Composite class** is used to aggregate any class that implements the **component interface.**

**A leaf class** represents a non-composite type. It is not composed of other components.

You may have other composite or leaf classes in practice not just two, but there will only be one overall component interface or abstract superclass. A composite object can contain other composite object, since the composite class is a subtype of component. This is known as **recursive composition**

It is easier to think of composite design patterns as **trees**:

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/composite-diagram-4.png" width="500" hight="500"/>
</p>

The Composite design pattern is used to address two issues:

- How de we use individual types of objects to build a tree-like structure?
- How can we treat the individual types without checking their types?

Solve this by enforcing **polymorphism** across each class through implementing **an interface** (or inheriting from a super class) and use technique recursive composition which allows objects to be composed of other objects that are of a common type.

**Real World example**

> Every organization is composed of employees. Each of the employees has the same features i.e. has a salary, has some responsibilities, may or may not report to someone, may or may not have some subordinates etc.
We will use example of how buildings are composed of generic housing structures

**Class Diagram of the example**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/composite-diagram-5.png" width="500" hight="500"/>
</p>

**IStructure**: is the **component interface** to describe building like a house, a floor or a room

**Housing**: is the composite class and it's type of `IStructure` and can contains other structures like floors or other housing objects.

**Room**: is the leaf class and it's a type of `IStructure` but cannot contains another room so its leaf.

**The Steps to implement the composite pattern**

- **Step1:** Design the interface the defines the overall type

```csharp
public interface IStructure
{
    public void enter();
    public void exit();
    public void location();
    public string getName();
}
```

- **Step 2:** Implement the composite class

```csharp
public class Housing : IStructure
{
    private List<IStructure> _structures;
    private string Address;

    public Housing(string address)
    {
        this._structures = new List<IStructure>();
        this.Address = address;
    }
    
    public string getName()
    {
        return this.Address;
    }

    public int addStructure(IStructure component)
    {
        _structures.Add(component);
        return this._structures.Count - 1;
    }
    public IStructure getStructure(int componentNumber)
    {
        return this._structures[componentNumber];
    }

    public void enter()
    {
        Console.WriteLine("You have entered the build: " + this.getName());
    }

    public void exit()
    {
        Console.WriteLine("You have exit the build: " + this.getName());
    }

    public void location()
    {
        Console.WriteLine("you are currently in " + this.getName() + ". It has");
        foreach (var str in this._structures)
        {
            Console.WriteLine(str.getName());
        }
    }
}
```

- **Step 3:** Implement the leaf class

```csharp
public class Room : IStructure
{
    public string name;

    public void enter()
    {
        Console.WriteLine("you have entered the " + this.name);
    }

    public void exit()
    {
        Console.WriteLine("you have left the " + this.name);
    }

    public string getName()
    {
        return name;
    }

    public void location()
    {
        Console.WriteLine("you have currently in the " + this.name);
    }
}
```

- **In main program/client**

```csharp
class Program
{
    static void Main(string[] args)
    {
        Housing building = new Housing("123 street");
        Housing floor1 = new Housing("123 street- First Floor");
        int firstFloor = building.addStructure(floor1);

        Room washroom1m = new Room("1F Mean's Washroom");
        Room washroom1w = new Room("1F Women's Washroom");
        Room common1 = new Room("1F Common Area");

        int firstMeans = floor1.addStructure(washroom1m);
        int firstWomens = floor1.addStructure(washroom1w);
        int firstcommon = floor1.addStructure(common1);

        building.enter(); // enter the building
        Housing currentFloor = (Housing)building.getStructure(firstFloor);
        currentFloor.enter(); // walk into the first floor

        Room currentRoom = (Room)currentFloor.getStructure(firstMeans);
        currentRoom.enter(); // walk into the men's room;
        currentRoom = (Room)currentFloor.getStructure(firstWomens);
        currentRoom.enter(); // walk into the women's room
        currentRoom = (Room)currentFloor.getStructure(firstcommon);
        currentRoom.enter(); // walk into the common area
    }
}
```

### Proxy Pattern

**The proxy** acts as **lightweight version** of the **original object,** and still able to accomplish the same tasks but may send requests to original object to achieve them. In a proxy pattern setup, a proxy is responsible for representing another object called the **subject.**

Proxy Pattern provides a surrogate or placeholder for another object to control access to it. Like a **gateway** for an object

**Proxy Design Pattern** allows a **proxy class** to represent and wraps a **real "subject" class** which are a part of your system to hide its **reference** like **sensitive info** or resource **intensive to instantiate**.

So the client will interact with the proxy class instead of real "subject" class, **So why we use a proxy class and its types**?

- **To act as a virtual proxy** where the proxy class is used in place of a real class like using on Images and web pages or graphics editors, because single high image can be extremely large. or you have a heavyweight service that wastes system resources by being always up, even you don't need it at this time
- **To act as a protection proxy** in order to control access to real subject class like using on learning management system that checks the credentials of a user or checking the count of Free SMS subscription
- **To act as a remote proxy** where the proxy class is local and the real subject class exists remotely like using on Google API Document on your machine and in google server as third-party API

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/proxy-diagram-1.png" width="500" hight="500"/>
</p>


<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/proxy-diagram-2.png" width="500" hight="500"/>
</p>


**Example**

> Below is an example of a UML diagram for an online retail store with global distribution and warehousing. In this scenario, you need to determine which warehouse to send orders to. A system will prevent your warehouses from receiving orders that they cannot fulfill. A proxy may protect your real subject, the warehouses, from receiving orders if the warehouses do not have enough stock to fulfill an order.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/proxy-diagram-3.png" width="500" hight="500"/>
</p>

**Steps to Implement Proxy Pattern**

- Step 1: Design the subject interface

```csharp
public interface IOrder
{
    public void FulFillOrder(Order order);
}
```

- Step 2: Implement the real subject class

```csharp

public class Warehouse : IOrder
{
    private Dictionary<int, Item> Stock = new Dictionary<int, Item>();
    private string Address;

    public void FulFillOrder(Order order)
    {
        foreach (var item in order.ItemList)
        {
            this.Stock.Remove(item.Id);
        }

        // process the order for shipment and dlivery
    }

    public int CurrentInventory(Item item)
    {
        if (Stock.ContainsKey(item.Id))
        {
            return Stock[item.Id].Id;
        }
        return 0;
    }
}
```

- Step 3: Implement the proxy class

the `OrderFulfillment` class **checks** warehouse inventory and **ensures** that an order can be completed **before sending** requests to the warehouse. To do this, it asks each warehouse if it has enough stock of a particular item. If a warehouse does, then the item gets added to a new Order object that will be sent to the Warehouse. The OrderFulfillment class also lets you separate order validation from the order fulfillment by separate them into two pieces. This improves the overall rate of processing an order, as the warehouse does not have to worry about the validation process or about re-routing an order if it cannot be fulfilled.

The `OrderFulfillment` class can be improved with other functionalities, such as prioritizing sending orders to warehouses based on proximity to the customer.

```csharp
public class OrderFulFillment : IOrder
{
    private List<Warehouse> Warehouses = new List<Warehouse>();

    public void FulFillOrder(Order order)
    {
        // for each item in a customer order, check each warehouse to see if it is in stock
        // if it is then create a new order for that warehouse
        // else check the next warehouse

        // Send the all the Orders to the warehouse(s)
        // after you finish iterating over all the items in
        // the original Order.

        foreach (var item in order.ItemList)
        {
            foreach (var warehouse in Warehouses)
            {
                // ..... 
								// if item in stock
								// warehouse.FulFillOrder(order);
            }
        }
    }
}
```

### Decorator Pattern

**The decorator pattern** adds new functionality to objects without modifying their defining classes. Like Open–closed principle.

Decorator Pattern allows additional behaviors or responsibilities to be dynamically **attached to an object,** through the use of **aggregation** to combine behaviors at **runtime**.

**Decorator** provide a flexible alternative to sub classing for extending functionality. Also Know as: **Wrapper**

**Like** a Black Coffee, Milk Coffee, Whip Coffee, and Vanilla Coffee

- Black Coffee = the base
- Milk Coffee = Black Coffee + Milk
- Whip Coffee = Black Coffee + Milk + Whip
- Vanilla Coffee = Black Coffee + Milk + Whip + Vanilla

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/decorator-adding-functionality.png" width="100" hight="100"/>
</p>

**Real World Example**

> Imagine you run a car service shop offering multiple services. Now how do you calculate the bill to be charged? You pick one service and dynamically keep adding to it the prices for the provided services till you get the final cost. Here each type of service is a decorator.

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/decorator-diagram-1.png" width="500" hight="500"/>
</p>

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/decorator-diagram-2.png" width="500" hight="500"/>
</p>

**Decorator** is an **abstract class** that implements component interface to aggregates other types of component which allow use to "stack" components on top of each other.

**Decorator** serves as the abstract superclass of concrete decorator classes that will each provide an **increment of behavior**.

We build the stack of components starting with an instance of `ConcreteComponent` class and continuing with subclasses of the decorator abstract class.

**Example**

> You have a SMS service that provide sending SMS messages, you need to add more functionality when the SMS message has been sent, you will notify the customer at his email.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/decorator-diagram-3.png" width="500" hight="500"/>
</p>

you can define any number of additional behaviors you want to `ConcereteSMSService` like `NotificationEmailDecorator`, that's better, unlike if you use inheritance of ConcereteSMSService, you will need to create a class for every combination of these behaviors

**Steps to implement Decorator Pattern**

- **Step 1:** Design the component interface

```csharp
public interface ISMSService
{
    public string SendSMS(string custId, string mobile, string sms);
}
```

- **Step 2:** Implement the interface with your base concrete component class

```csharp
public class ConcereteSMSService : ISMSService
{
    public string SendSMS(string custId, string mobile, string sms)
    {
        return $"CustomerId {custId},the message {sms}, had sent to {mobile} successfully";
    }
}
```

- **Step 3:** Implement the interface with your abstract decorator class

```csharp
public abstract class AbstractDecorator: ISMSService
{
    protected ISMSService notificationService;

    public AbstractDecorator(ISMSService service)
    {
        notificationService = service;
    }

    public string SendSMS(string custId, string mobile, string sms)
    {
        if (notificationService != null)
        {
            return notificationService.SendSMS(custId, mobile, sms);
        }
        else
        {
            return "Notification service not initialized!";
        }
    }
}
```

- **Step 4:** inherit from the abstract decorator and implement the component interface with concrete decorator classes

```csharp
public class NotificationEmailDecorator : AbstractDecorator
{
    public NotificationEmailDecorator(ISMSService service) : base(service)
    {
    }

    public string SendSMSAndEmailNotifier(string custId, string mobile, string sms)
    {
				// get the base and add on it
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.SendSMS(custId, mobile, sms));

        // decorator method to send mail (additional functionality)
        // sending email logic here
        result.AppendLine($"this mail about sending SMS {sms}, send to {custId}, at {DateTime.Now.ToLongDateString()}");

        return result.ToString();
    }
}
```

- **In Main Program/client**

```csharp
class Program
{
    static void Main(string[] args)
    {
        ISMSService smsService = new ConcereteSMSService();
        // any additional Concrete Decorators
        NotificationEmailDecorator emailDecorator = new NotificationEmailDecorator(smsService);

        Console.WriteLine(emailDecorator.SendSMSAndEmailNotifier("123", "01154321101", "message 1"));

			// Output
			// CustomerId 123,the message message 1, had sent to 01154321101 successfully
			// this mail about sending SMS message 1, send to 123, at Monday, January 25, 2021
    }
}
```

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

### Template Method Pattern

As name suggest, You may have used a template for writing your resume. The template would define the overall structure of the document and leave the details to be added in by you.

**The template method** defines an **algorithm's steps** generally letting the implementation of some steps to subclasses. It define the operations into Abstract class to allow subclasses override. It depend in **generalization and inheritance**

Note that the classes may choose to ignore overriding certain steps or choose to rely on the default implementation provided by the abstract class.

Think of it like another technique to use when you notice you have two separate classes with very **similar functionality and very similar order of operations**, After using generalization you can share the functionality between the classes.

**Real world example**

> Suppose we are getting some house built. The steps for building might look like
- Prepare the base of house
- Build the walls
- Add roof
- Add other floors
The order of these steps could never be changed i.e. you can't build the roof before building the walls etc, but each of the steps could be modified for example walls can be made of wood or polyester or stone.

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/template-method-pattern-1.png" width="500" hight="500"/>
</p>

**Example**

> imagine you are an executive chef, The two most popular dishes are spaghetti with tomato sauce and meatballs, and penne noodles with alfredo sauce and chicken. Both dishes have the same steps to cook like boil water, cook pasta, add the sauce and garnish etc but each one have it's own implementation depending, each dish has a different sauce, protein, and garnish

**UML Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/template-method-pattern-2.png" width="500" hight="500"/>
</p>

**Steps to implement it**

- **Step 1**: Define Abstract class and Template Method

```csharp
public abstract class PastaDish
{
    // The template method defines the skeleton of an algorithm.
    public void MakeRecipe()
    {
        // The fixed steps
        BoilWater();
        AddPasta();
        CookPasta();
        DrainAndPlate();
        AddSauce();
        AddProtein();
        AddGarnish();
        Console.WriteLine("==========================================");
        Console.WriteLine("The dish has prepared");
        Console.WriteLine("==========================================");
    }

    protected abstract void AddPasta();
    protected abstract void AddSauce();
    protected abstract void AddProtein();
    protected abstract void AddGarnish();

    private void BoilWater()
    {
        Console.WriteLine("Boiling Water");
    }

    private void CookPasta()
    {
        Console.WriteLine("cooking pasta");
    }

    private void DrainAndPlate()
    {
        Console.WriteLine("Draining and plating");
    }
}
```

- **Step 2**: Inherit them in concrete class

```csharp
public class SpaghettiMeatballs : PastaDish
{
    protected override void AddGarnish()
    {
        Console.WriteLine("Adding Garnish for Spaghetti dish");
    }

    protected override void AddPasta()
    {
        Console.WriteLine("Adding Pasta for Spaghetti dish");
    }

    protected override void AddProtein()
    {
        Console.WriteLine("Adding Protein for Spaghetti dish");
    }

    protected override void AddSauce()
    {
        Console.WriteLine("Adding Sauce for Spaghetti dish");
    }
}
```

```csharp
public class PennaAlfredo : PastaDish
{
    protected override void AddGarnish()
    {
        Console.WriteLine("Adding Garnish for Penna Alfraedo dish");
    }

    protected override void AddPasta()
    {
        Console.WriteLine("Adding Pasta for Penna Alfraedo dish");
    }

    protected override void AddProtein()
    {
        Console.WriteLine("Adding Protein for Penna Alfraedo dish");
    }

    protected override void AddSauce()
    {
        Console.WriteLine("Adding Sauce for Penna Alfraedo dish");
    }
}
```

- **In Main Program**

```csharp
class Program
{
    static void Main(string[] args)
    {
        PastaDish spaghettiDish = new SpaghettiMeatballs();
        spaghettiDish.MakeRecipe(); // Invoke Tempate Method

        PastaDish pennaDish = new PennaAlfredo();
        pennaDish.MakeRecipe(); // Invoke Tempate Method
    }
}
```
### Chain Of Responsibility Pattern

As name suggest, **A chain of objects that are responsible for handling requests**, It is a series of **handler objects** that are linked together.

When a client object sends a request, the first handler in the chain will try to process it. If the handler can process the request, then the request ends with this handler. However, if the hander cannot handle the request, then the request is sent to the next handler in the chain. This process will continue until a handler can process the request. If the last handler cannot process then the request is not satisfied.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/chainOfResponsibility-1.png" width="500" hight="200"/>
</p>

**How to work?** so like trying everything until something works. Each object tries to handle the request until one is able to successfully handle it like **Exception handling in programming languages**

**Where to use?** examples like setting up a lot of ways to filter the emails from spam, social media, Promotions. or Validating something

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/chainOfResponsibility-2.png" width="500" hight="200"/>
</p>

**Real world example**

> For example, you have three payment methods (`A`, `B` and `C`) setup in your account; each having a different amount in it. `A` has 100 USD, `B` has 300 USD and `C` having 1000 USD and the preference for payments is chosen as `A` then `B` then `C`. You try to purchase something that is worth 210 USD. Using Chain of Responsibility, first of all account A will be checked if it can make the purchase, if yes purchase will be made and the chain will be broken. If not, request will move forward to account `B` checking for amount if yes chain will be broken otherwise the request will keep forwarding till it finds the suitable handler. Here `A`, `B` and `C` are links of the chain and the whole phenomenon is Chain of Responsibility.

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/chainOfResponsibility-3.png" width="500" hight="500"/>
</p>

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/chainOfResponsibility-4.png" width="500" hight="500"/>
</p>

**Algorithm to solve problem if it's rules doesn't match and forgets to pass the request into the next filter, We will use `Template Method Pattern` to make sure follow this algorithm.**

- Check if rules matches
- If it matches, do something specific
- If it doesn't match, call the next filter/handler in the list

The intent of this pattern is to **avoid coupling** the sender to the receiver by giving more than object

What the benefits?

- A more extensible, object-oriented and dynamic implementation
- Easily re-arrange in what order the handlers operate
- Clear approach with single responsibility in min instead of different conditions

**Example**

> See the [example 1](https://github.com/aboelkassem/Design-Patterns/tree/main/src/DesignPattern/DesignPattern/Behavioral/ChainOfResponsibilityPattern/NoSeparationExample) of Payment Processing system in C# with no separation
 See the [example 2](https://github.com/aboelkassem/Design-Patterns/tree/main/src/DesignPattern/DesignPattern/Behavioral/ChainOfResponsibilityPattern/SeparationExample) of Payment Processing system in C# with improvement separation

### State Pattern

**State Pattern** lets you change the behavior of a class when the state changes.

**State Pattern** mean that the objects in your code are aware of their current state. They can choose an appropriate behavior based on their current state. When their current state changes, this behavior can be changed. It is used when you need to change the behavior of an object based upon the state.

you can also you the pattern to simplify methods with long conditionals that depend on the object state.

**UML Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/state-pattern-1.png" width="500" hight="500"/>
</p>

**Real World Example**

> Imagine you are using some drawing application, you choose the paint brush to draw. Now the brush changes its behavior based on the selected color i.e. if you have chosen red color it will draw in red, if blue then it will be in blue etc.

**Example**

A vending machine has several states, and specific actions based on those states, Like `Idle` when the machine stay waiting for action, `Has One Dollar` when someone entered a dollar coin to buy some thing, `Out of Stock` when the machine doesn't have any of this item. and some actions like `doRetunMoney` or `doReleaseProduct`

**State Diagram of the example**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/state-pattern-2.png" width="500" hight="500"/>
</p>

**Class Diagram of the example**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/state-pattern-3.png" width="500" hight="500"/>
</p>

**Steps to apply State Pattern**

- **Step 1:** define State interface

```csharp
public interface State
{
    // all potential vending machine triggers and events
    // that change the state of the object
    public void InsertDollar(VendingMachine vendingMachine);
    public void EnjectMoney(VendingMachine vendingMachine);
    public void Dispense(VendingMachine vendingMachine);
}
```

- **Step2:** Implement the states class that implement this interface

```csharp
public class IdleState : State
{

    public void InsertDollar(VendingMachine vendingMachine)
    {
        Console.WriteLine("dollar inserted");
        vendingMachine.CurrentState = vendingMachine.HasOneDollarState;
    }

    public void EnjectMoney(VendingMachine vendingMachine)
    {
        Console.WriteLine("no money to return");
    }

    public void Dispense(VendingMachine vendingMachine)
    {
        Console.WriteLine("payment required");
    }
}

public class HasOneDollarState : State
{

    public void InsertDollar(VendingMachine vendingMachine)
    {
        Console.WriteLine("already have one dollar");

        vendingMachine.doReturnMoney();
        vendingMachine.CurrentState = vendingMachine.IdleState;
    }

    public void EnjectMoney(VendingMachine vendingMachine)
    {
        Console.WriteLine("returning money");

        vendingMachine.doReturnMoney();
        vendingMachine.CurrentState = vendingMachine.IdleState;
    }

    public void Dispense(VendingMachine vendingMachine)
    {
        Console.WriteLine("releasing product");

        if (vendingMachine.Count > 1)
        {
            vendingMachine.doReleaseProduct();
            vendingMachine.CurrentState = vendingMachine.IdleState;
        }
        else
        {
            vendingMachine.doReleaseProduct();
            vendingMachine.CurrentState = vendingMachine.OutOfStockState;
        }
    }
}

public class OutOfStockState : State
{

    public void InsertDollar(VendingMachine vendingMachine)
    {
        Console.WriteLine("sorry, there are no items in the stock");
        vendingMachine.doReturnMoney();
    }

    public void EnjectMoney(VendingMachine vendingMachine)
    {
        vendingMachine.doReturnMoney();
    }

    public void Dispense(VendingMachine vendingMachine)
    { }
}
```

- The Vending machine class will be like this

```csharp
public class VendingMachine
{
    public State IdleState { get; set; } = new IdleState();
    public State HasOneDollarState { get; set; } = new HasOneDollarState();
    public State OutOfStockState { get; set; } = new OutOfStockState();

    public State CurrentState { get; set; }
    public int Count { get; set; }

    public VendingMachine(int count)
    {
        if (count > 0)
        {
            CurrentState = IdleState;
            this.Count = count;
        }
        else
        {
            CurrentState = OutOfStockState;
            this.Count = 0;
        }
    }

    public void insertDollar() => CurrentState.InsertDollar(this);

    public void ejectMoney() => CurrentState.EnjectMoney(this);

    public void dispense() => CurrentState.Dispense(this);

    public void doReturnMoney() => Console.WriteLine("Returning money for the user");

    public void doReleaseProduct() => Console.WriteLine("Returning item product for the user");
}
```

### Command Pattern

**Command Pattern** allows you to **encapsulate actions/methods in objects**.

The usual way is Sender object call method in Receiver object to run this method. The command pattern creates a command object in between the sender and receiver. Command Pattern means creates command objects instead of normal methods

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/command-pattern-1.png" width="300" hight="100"/>
</p>

The **Sender** creates a **command object**, **Invoker** invokes the command object do what it’s supposed to do. The invoker keeps track of the commands, manipulates them and invokes them.

The important thing is that the command pattern lets you **do things to request** that you wouldn't be able to do if they were simple method calls from one object to another.

Creating these requests as objects allows you to create very useful functionality in your software.

**what is the purposes of the command pattern?**

- **Store and schedule different requests.** When you use an method of another object, you can store this command objects into lists, manipulate them before they are completed, put them onto a queue.
- Allowing commands to be undone or redone like **undo or redo** edits in a document or any type in applications

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/command-pattern-2.png" width="500" hight="500"/>
</p>

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/command-pattern-3.png" width="500" hight="500"/>
</p>


<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/command-pattern-4.png" width="500" hight="500"/>
</p>

**Real World Example**

> A generic example would be you ordering food at a restaurant. You (i.e. `Client`) ask the waiter (i.e. `Invoker`) to bring some food (i.e. `Command`) and waiter simply forwards the request to Chef (i.e. `Receiver`) who has the knowledge of what and how to cook. Another example would be you (i.e. `Client`) switching on (i.e. `Command`) the television (i.e. `Receiver`) using a remote control (`Invoker`).

**UML Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/command-pattern-5.png" width="500" hight="500"/>
</p>

- **execute():** do the work that the command is supposed to do
- **unexecute():** do the undoing the command
- **isReversible():** determines if the the command is reversible, return `true` if the command can be undone
- **Receiver Class**: deals with the actual work of completing the command

**The benefits of Command Pattern**

- **Manipulate the commands as objects not methods calls**, which enable them add more functionalities like putting commands into queues, adding an undo/redo function.
- **Decouples the objects of your software**

> For Example see [the source code](https://github.com/aboelkassem/Design-Patterns/tree/main/src/DesignPattern/DesignPattern/Behavioral/CommandPattern)

### Mediator Pattern

Mediator pattern adds a **third party object** (called *`mediator`*) to control the **interaction** between two or more objects (called `colleagues`). It helps reduce the coupling between the classes communicating with each other by encapsulating them. Because now they don't need to have the knowledge of each other's implementation.

Imagine that you want the house of the future. You want your house to change its own temperature once you have left, to brew your coffee when the alarm on your phone goes off, and to load the latest Globe and Mail news issue onto your tablet if you're home and it's Saturday morning, you keep adding more rules and more devices. Eventually you realize interactions between two objects is becoming complicated and difficult to maintain like this:

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/mediator-pattern-1.png" width="500" hight="500"/>
</p>

To be solve this problem and simply use mediator pattern, **In the Mediator pattern**, you will add an object that will talk to all of these other objects and coordinate their activities. Now, they all interact through the mediator. The communication between an object and the mediator is **two-way:** the object informs the mediator when something happens. Then The mediator can perform logic on these events.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/mediator-pattern-2.png" width="400" hight="400"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/mediator-pattern-3.png" width="400" hight="400"/>
</p>

**Real World Example**

> A general example would be when you talk to someone on your mobile phone, there is a network provider sitting between you and them and your conversation goes through it instead of being directly sent. In this case network provider is mediator.

**UML Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/mediator-pattern-4.png" width="500" hight="500"/>
</p>

**Example**

The example will be the `chatroom` between team member `developer` and `tester`

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/mediator-pattern-5.png" width="500" hight="500"/>
</p>

- Define the mediator abstract class

```csharp
public abstract class Chatroom
{
    public abstract void Register(TeamMember member);
    public abstract void Send(string from, string message);
    // Send message to the specific objects like sending to only developers, only testers
    public abstract void SendTo<T>(string from, string message) where T : TeamMember;
}
```

- Define the Colleague abstract class that talk to the mediator

```csharp
public abstract class TeamMember
{
    public string Name { get; }
    private Chatroom chatroom;

    public TeamMember(string name)
    {
        this.Name = name;
    }

    // Set Mediator
    internal void SetChatroom(Chatroom chatroom)
    {
        this.chatroom = chatroom;
    }

    // Sending messages to mediator
    public void Send(string message)
    {
        this.chatroom.Send(this.Name, message);
    }
    // Receiving a chat message
    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"from {from}: '{message}'");
    }

    public void SendTo<T>(string message) where T : TeamMember
    {
        this.chatroom.SendTo<T>(this.Name, message);
    }
}
```

- Implement Concrete mediator

```csharp
public class TeamChatroom : Chatroom
{
    private List<TeamMember> members = new List<TeamMember>();

    // References
    // just set up/register connection between mediator and colleague 
    public override void Register(TeamMember member)
    {
        member.SetChatroom(this);
        this.members.Add(member);
    }

    // Sending this message for each members
    public override void Send(string from, string message)
    {
        this.members.ForEach(m => m.Receive(from, message));
    }

    // Register team members at once
    public void RegisterMembers(params TeamMember[] teamMembers)
    {
        foreach (var member in teamMembers)
        {
            this.Register(member);
        }
    }

    public override void SendTo<T>(string from, string message)
    {
        this.members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
    }
}
```

- Implement concrete colleagues/team members

```csharp
public class Developer : TeamMember
{
    public Developer(string name): base(name)
    {

    }

    public override void Receive(string from, string message)
    {
        Console.Write($"{this.Name} ({nameof(Developer)}) has received: ");
        base.Receive(from, message);
    }
}

public class Tester : TeamMember
{
    public Tester(string name) : base(name)
    {

    }

    public override void Receive(string from, string message)
    {
        Console.Write($"{this.Name} ({nameof(Tester)}) has received: ");
        base.Receive(from, message);
    }
}
```

- In Main program

```csharp
class Program
{
    static void Main(string[] args)
    {
        var teamChat = new TeamChatroom();

        var mohamed = new Developer("Mohamed");
        var ahmed = new Developer("Ahmed");
        var shimaa = new Tester("Shimaa");
        var sara = new Tester("Sara");

        teamChat.RegisterMembers(mohamed, ahmed, shimaa, sara);

        mohamed.Send("Hey everyone, i'm mohamed, lets get some fun");
        Console.WriteLine();
        shimaa.Send("Oh, i have found issue while i testing your app");
        Console.WriteLine();

        // developer objects will only receive this message
        ahmed.SendTo<Developer>("hey developers, i have bug i cannot fix it, anyone can help?");
    }
}
```

See [another example](https://github.com/OlufemiFowosire/PluralsightDesignPatternsPracticeCodes/tree/cf8a3d8eb5809b413c6a7419dc6943f2821902ea/Patterns/Mediator/MediatorDemo/MarkerPositions) for marker positions with WebForms

### Observer pattern

**The observer design pattern** is a pattern where a **subject** keeps a list of **observers**. Observers rely on the subject to inform them of changes to the state of the subject.

Simulate this scenario, imagine you follow a Youtube channel or blog or even Twitter, you visit them multiple times in day, you need to be active and know everything when blog posted, but what if you get bored? A better solution is when a blog posted or video uploaded the youtube or the blog notify you, so just make a subscribe, and when the video updated, the youtube will notify all the subscribers. Or in Twitter when you follow someone you are essentially asking Twitter to send you (**the observer**) tweet updates of the person (**the subject)** you followed. so in this example blog is a **`Subject`** who generates the updates, subscribers is **`Observers`** who is interested in the updates

So **subject** superclass has three methods:

- Allow a new observer to subscribe
- Allow a current observer to unsubscribe
- Notify all observers about a new blog post

So **Observer interface** which has methods that an observer can be notified to update itself.

**Real World Example**

> A good example would be the job seekers where they subscribe to some job posting site and they are notified whenever there is a matching job opportunity.

**Sequence Diagram of the example**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/observe-pattern-1.png" width="500" hight="500"/>
</p>

**Class Diagram**

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/Images/observe-pattern-2.png" width="500" hight="500"/>
</p>

- `Observer` interface

```csharp
public interface Observer
{
    public void update();
}
```

- `Subject` Superclass code

```csharp
public class Subject
{
    private List<Observer> Observers = new List<Observer>();

    public void registerObserver(Observer observer)
    {
        Observers.Add(observer);
    }
    public void unregisterObserver(Observer observer)
    {
        Observers.Remove(observer);
    }
    public void notify()
    {
        foreach (var observer in Observers)
        {
            observer.update();
        }
    }
}
```

- `Blog` class which is subclass from `Subject`

```csharp
public class Blog : Subject
{
    public string State { get; }

		public void setStatus(String status){
	      this.status = status;
	      notify();
		 }

    // other responsibilities
}
```

- `Subscriber` class which implement `Observer` class

```csharp
public class Subscriber : Observer
{
    public void update()
    {
        // get the blog change or the changed status 
    }
}
```
