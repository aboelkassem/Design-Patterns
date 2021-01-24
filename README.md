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
        **var resposne = service.request(jsonString);**
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
        **int status = webRequester.request(obj);**

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

**Housing**: is the composite class and it's type of **IStructure** and can contains other structures like floors or other housing objects.

**Room**: is the leaf class and it's a type of IStructure but cannot contains another room so its leaf.

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
