# Software Architect and Design Roles in Industry
the software designer or a software architect role can look very different from company to company in Characteristics like company size, the scope of the project, the experience of the development team, the organizational structure and the age of the company

<b>Software Designer</b> responsible for outlining a software solution to a specific problem by design the details of individual components and their responsibilities.
<b>in short:</b> software looks at the lower-lever aspects of the system, focuses on the smaller spaces within.

**Software Architect** responsible for looking the entire system and choosing appropriate frameworks, data storage, solutions and determining how components interact with each other

**in short:** software looks at the higher-lever/bigger picture aspects of the system, focuses on the major structures and services.
**Great software designers and architects are detail-oriented, forward thinkers**

# Object-Oriented Modeling
when solving a problem, object-oriented modeling involves the practice of representing key concepts through **objects** in your software. Depending on the **problem**, **many concepts,** even **instances of people, places,** or things become **distinct objects** in the software
### **why should you use objects to represent things in your code?**

- to keeping your code **organized, flexible and reusable**
- keeps code organized by having **related details and specific functions** in distinct, easy to find places to creates **flexibility**
- flexibility enable you **easily change details** in a modular way **without affecting the rest of the code,** and **reuse code to keep your program simple.**

**With object-oriented thinking,** you often think of everything as objects event living things and all these objects are self-aware event inanimate things.

# Design in the Software Process

you can think of developing software as a **process that takes a problem and produces a solution** involving software.

it's an iterative process, taking set of requirements ⇒ working and tested implementation ⇒ building a complete solution
![](https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/agile-process.png)
Why projects fail ? it's related to issues in requirements and design

so it's important to take your time in gathering/understanding the requirements and create a design

![](https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/misunderstanding-requirments.png)
We get **requirements** by asking **questions** about issues that the clients may not **considered** beside **identifying specific needs.**

So to know the trade-offs the client needs to make in the solution with a **clear idea** of what you are trying to **accomplish,** you can use **Conceptual Design mock-ups** and **Technical Design diagrams.**
For the design phase, you will have to think like an **architect**, which mean thinking about the structure and behavior of your software.

starting with **eliciting requirements** which involves not only listening to what the client is telling you, but asking questions to clarify what the client has not told you, once this revealing follow up questions you now have an initial set of requirements allowing you to start thinking of possible designs.

this requirements involves producing a Conceptual Design and Technical Design which representing two kinds of artifacts ⇒  **Conceptual mockups** and **Technical diagrams**

**Conceptual mockups** provide your initial thoughts for how the requirements will be satisfied, focusing in **components** and **connections**, each component has a **responsibility** of it do or what the it's purpose and avoid technical details to clarify design decisions with clients and users.

**in software conceptual mockups can be a hand drawn sketch or draw made using computer tools.**

**Technical diagrams** is responsible for describing how these responsibilities are met, by start specifying the technical details of each component, this done by splitting components into smaller and smaller components to help coordinate development work.

**Components** turn into collections of function, classes or other components, these pieces then represent much simpler problem that developers can implement. 

### Example

for university course search website task

**Requirement** ⇒ As a learner, I want to search for relevant courses through a search page

**Conceptual mockups** ⇒ components like search page and course, search page has the responsibility of searching for a relevant courses.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/example1-CM.png" width="300" hight="300"/>
</p>

**Technical design ⇒** take each component by technical details by answering the following question....how does the search page fulfill its responsibility of searching?

- does the page need to talk to an external system ? or the university already has a course database component to connect Search Page Component with Course Database Component
<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/example1-TD.png" width="300" hight="300"/>
</p>

**if the design satisfying requirements ?** some software design decisions will involve tradeoffs in different quality attributes such as **performance**, **convenience** and **security.** so it's  important to consider how quality attributes can compete in a proposed solution under different situations. Then, taking this into account and weighing it against the requirements of the product, a suitable compromise can be determined.

### **Satisfying Qualities**

Qualities are achieved through satisfying functional and nonfunctional requirements, which in turn are the basis for the design process.

For software, there are **Functional Requirements** that describe that system or application is expected to do.  For example, if you are designing a media app, the app must be able to download and play a full length movie. So the key quality is simply **correctness** to build software design solution to meet such requirements correctly.

**Non-Functional Requirements** that specify how well the system or application **does what it does**. Such requirements may describe how well the software runs in particular situations. Non-functional requirements to satisfy might include **performance, resource usage, and efficiency**; these requirements can be measured from the running software. For example the media app can have non-functional requirements to download a full length movie at a specific speed and to play such a movie within a memory limit. other qualities non-function satisfies is **reusability, flexibility, and maintainability.**

After design get detailed and implementation is constructed, required qualities should be verified though techniques like **reviews** and **tests,** also **feedback from end-users.**

You must satisfy qualities that matter to users as well as for it's developers, so when your software structure suits the balance of qualities desired, how structure is organized may affect the **performance** as seen by the **users,** as well as the **re-usability and maintainability** as seen by the **developers.**

Below are some common trade-offs in qualities for software design:

- Performance and maintainability – High performance code may be **less clear** and **less modular**, making it **harder to maintain.** Alternately, extra code for backward compatibility
- Performance and security – Extra overhead for high security may **reduce performance**

so you have to strike a **balance** during design. You should ask how much performance, maintainability, security or backward compatibility is needed.

### Class Responsibility Collaborator (CRC)

when identifying **components, connections and responsibilities** from some requirements when forming the conceptual design. CRC cards hep you to **organize your components into classes**, identifying the **responsibilities** and determine how they will **collaborate with each other.** It **record and organize and refine** the components into your software.

- CRC Structure
<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/crc_card.png" width="300" hight="300"/>
</p>
**Collaborators** are other classes that the class **interacts** with to fulfill its responsibilities. So in collaborators section you list other components that your current component connects with.

**Example on ATM bank machine.**
<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/crc_customer.png" width="300" hight="300"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/crc_bank.png" width="300" hight="300"/>
</p>

**CRC** help you to organize the your ideas and extract the needed objects and it's relationships. and can be used for prototyping and simulation.

**For example**, you may wondering in above example, **How bank machine authenticate bank customer ?**

So this add another component is **Bank** to authenticate from it. another question **how this back and bank machine communicate ?** it add another component is **Network,** also we need to **secure this network** so we will add another component is **Encryption** and so far.

Also you man notice that bank machine consist of other objects like **Card Reader, Keypad, Display, Cheque Slot, Cash Dispenser.** can be written in their own cards

# Object-Oriented Modeling

One approach to help make the design process easier is the object-oriented approach. This allows for the description of concepts in the problem and solution spaces as **objects**. objects are a notion that can be understood by both users and developers, because **object-oriented thinking** applies to many fields. This shared knowledge makes it possible for users and developers to discuss elements of complex problems. 

Even here, you don't go straight from the problem to writing the code, you have to do **Conceptual Design involving Object-Oriented Analysis** to identify the key objects in the problem. also **Technical Design involving Object-Oriented Design** to further refine the details of the objects including their attributes and behaviors.

The goal during Software Design is to construct and refine **models** of all the objects, these models are useful throughout the design process.

- **Entity** where initial focus during the design is placed in the problem space.
- **Control** objects that receive events and actions.
- **Boundary** that connect services outside your system.

The Models are expressed  in a visual notation, called **Unified Modelling Language (UML).**
## Evolution of Programming Languages

Programming languages evolved in similar fashion as **traditional languages**, each new programming language was developed to provide **solutions** to problems that previous languages were unable to adequately address. The ideas used in computer languages have caused a shift in **programming paradigms.**

In 1980s, Object-Oriented Design that are central of object-oriented programming became popular.

**The goal of object-oriented design is to:**

- Make an abstract data type easier write.
- Structure a system around abstract data types called **classes**
- Introduce the ability for an abstract data type to extend another by introducing a concept called **inheritance**

The advantages of using programming paradigms like OOP is that the system will mimic the structure of the problem meaning that any object-oriented program is capable of representing **real world objects** or ideas with more fidelity that allows developers to compartmentalize the data and how it can be manipulated in their own separate classes.

So **Object-Oriented Programming** is the **predominate programming paradigm.**

Most modern programming languages like Java, C++, C# are founded based on objects.

**Why this history ?**

as a developer you need to have a broad **understanding of what is out there in the industry today,** There are many systems that still use the older languages and design paradigms.

Also Object-oriented programming is a powerful tool, but is not only in your toolbox. Object-oriented design is not always the best approach for every thing because the design may not fit the problem, Remember to be efficient with your time event if this means taking a non-object-oriented approach.

Here is some **history of programming languages** and paradigms and the issues they met.
![](https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/COBOL-Fortran.png)
![](https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/C.png)
![](https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/Pascal.png)
![](https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/c%2B%2B_java_c%23.png)

## Four Design Principles

Object-oriented programming allows you to create models of how objects are represented in your system. However, to create an object-oriented program, you must examine the major design principles of such programs. Four of these major principles are: **abstraction, encapsulation, decomposition, and generalization.**

### Abstraction

Abstraction is one of the main ways that humans deal with complexity. It is the idea of simplifying a concept in the problem domain to its essentials within some **context**. Abstraction allows you to better understand a concept by breaking it down into a simplified description that **ignores unimportant details.** Also an abstraction for a concept should **make sense** for the concept's purpose. This idea applies **the Rule Of Least Astonishment**

**Rule Of Least Astonishment:** is the abstraction captures the essential attributes and behavior for a concept with **no surprises and no definitions** that fall beyond its scope. You don't want to surprise anyone trying to understand your abstraction with **irrelevant characteristics**.

It's up to you to choose the abstraction that is most appropriate for your purpose depending the context of your app.

**For example** the context is an academic setting, so abstraction for a student will be the essential characteristics/attributes of him:

- The courses they are currently taking
- Their grades in each course
- The Student ID number

Another examples for defining attributes of a cat from the context of a cat owner

- A cat will have basic attributes like name, color, favorite Nap location, microchip number

Also abstraction should describe a base **behaviors**, Like for **student** would be Studying, doing assignments, attending lectures which are responsibilities that student abstraction does for it's purpose. 

**Example** of abstraction of lion

- attributes like age, beard, size and it's color
- behaviors like hunting, eating and sleeping

In abstraction anything other than a concept's essential **attributes and behaviors** is irrelevant focusing the context and purpose of this object into our app to simplifying your class design so the are more focused and understandable to someone else viewing them.

**Abstraction UML Class diagram and C# Code**

Thinking of how we abstract **Food** object in CRC and Class diagram

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/association-ex.png" width="300" hight="300"/>
</p>

Class diagram contains

- Class Name which is **Food**
- Properties which define C# Members ⇒ [variable name]:[variable type]
- Operations which define C# Methods ⇒ name( [parameter list] ): [return type]

Class diagram are very close to implementation which making the translation to code very easy

So the following code is implemented of above class diagram

```csharp
public class Food
{
	public string GroceryId{ get; set; }
	public string Name{ get; set; }
	public string Manufacturer{ get; set; }
	public Date ExpiryDate{ get; set; }
	public double Price{ get; set; }

	public bool IsOnSale(){

	}
}
```

### Encapsulation

Encapsulation is a fundamental design principle in object oriented modeling and programming, Encapsulation forms a self-contained object by **bundling** the **data and functions** it requires to work, **expose an interface** whereby other objects can access and use it , **restricts access** to certain inside details. It keeps software modular, easier to work with and easy to manage.

So after **Abstraction** that determine the attributes and behaviors that are relevant about concept in some context ⇒ **Encapsulation** ensures that these characteristics are bundled together in the same class

- **For example** Student object should "**knows**" relevant data like degree program, Course object would "**know**" a list of students taking it, Professor object would "**know**" a list of courses teaches.

Also the methods manipulate the attribute values in object to achieve the actual behaviors, by **Exposing** some methods to be accessible to objects, and **restricts** other.

- **For example** Course can provide a method to allow a student to enroll in the course or Course allow professor to see the students in that course.

**Encapsulation helps with data integrity** so you can define methods and attributes of class to be **restricted** from outside to access except through specific methods. 

**Encapsulation can secure sensitive information** for example, allowing a Student class to store a degree program and GPA without reveals it's actual value so it has a method tells whether the student is in good standing for the degree program or not.

**Encapsulation helps with software changes** so the accessible interface of class will remain the same, while implementation of attributes and methods can change.

- **For example** Professor need to know student GPA, student have many ways to calculate his GPA like entering Student Information system or go to administrator to get. So Professor don't care how the student will get from.

In programming, this thinking called **Black Box** Thinking, you think of a class like a black box that you cannot see details inside of how attributes are represented or how methods compute the result, you just provide inputs and obtain outputs by calling methods so it doesn't matter what happens in the box to achieve the expected behaviors.

**Encapsulation** achieves **Abstraction Barrier** since the internal workings are not relevant to outside world to **reduces complexity** for the users of a class and **increases reusability** because another class only need to know the right method to call to get desired behavior. 

**Encapsulation UML Class diagram and C# Code Example** 

There are two different kinds of methods typically used to preserve data integrity. These are:

- **Getter Methods** are methods that retrieve data, and their names typically begin with get and end with the name of the attribute whose value you will be returning.
- **Setter Methods** change data, and their name typically begin with set and end with the name of the variable you wish to set. Also Setters are used to **set private attribute** in a safe way.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/encap-ex.png" width="400" hight="400"/>
</p>

```csharp
public class Student
{
	private float gpa;
	private string degreeProgram;

	public float getGPA(){
		return gpa;
	}
	public void setGPA(float newGPA){
		gpa = newGPA;
	}
	public string getDegreeProgram(){
		return DegreeProgram;
	}
	public void setDegreeProgram(string newDegreeProgram){
		if (gpa > 2.7){
			degreeProgram = newDegreeProgram;
		}
	}
}
```

### Decomposition
Decomposition is taking a **whole** thing and dividing it up into different **parts**, Or on flip side, taking a bunch of separate parts with different functionalities and **combining** them together to form a whole, Decomposition allows you to further beak down problems into pieces that are easier to understand and solve. 

**The general rule** for decomposition it to look at the different responsibilities of the some **whole** thing, and evaluate how you can **separate** them into different parts each with its own responsibility.

- **For example** when identifying the different parts of a **car** like transmission, motor, wheels, tires, doors, windows, seats and fuel. each of this part had a specific purpose to achieve the responsibilities of the whole.

**The Nature of Parts**

A whole might have a **fixed** or **dynamic** number of a certain type of part.

- If there is a **fixed number** then over the lifetime of the whole object it will have exactly that much of the part object, **for example** a refrigerator have fixed number of freezers and not change over time.
- Sometimes parts with a **dynamic number** meaning the whole object may gain new instances of those part objects objects over its lifetime, **for example** a refrigerator can have a dynamic number of food items over time, or passengers in car.

Note that a **part** can also serve as a **whole**, which is made up of further **parts**. For example, a kitchen is a part of a house. But the kitchen may be made up of further parts, such as an oven and a refrigerator.

**Composition** involving the lifetimes of the whole object and the part objects that are be related.

- **For example** the engine typically has the same lifetime as the car - when the engine goes, so does the car! The wheels, on the other hand, are replaced many times over the course of a car's life.
- Whole things may also contain parts that are **shared** with another whole at the same time. However, sometimes sharing a part is not possible or intended.

**Composition UML Class diagram and C# Code example**

There are three types of **relationships** found in decomposition that define the interaction between the whole and the parts:

- Association
- Aggregation
- Composition

**Association** is "some" relationship. This means that there is a loose relationship/no dependent between two objects. These objects may interact with each other for some time. for example, an object of a class may use services/methods provided by object of anther class like food and wine, student and sports, kitten and yarn. each of these relationships is between completely separate entities, if one object is **destroyed**, the other can **continue to exist.**

The following fig shows class diagram with two objects have association relationship

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/association-ex.png" width="400" hight="400"/>
</p>

<b>0..*</b> ⇒ means a Person object is associated with **zero or more** airline objects and the same with Airline object is associated with **zero or more** person objects.

```csharp
public class Student
{
    public void Play(Sport sport)
    {
			// statements
    }
}

public class Sport
{
	public string Name { get; set; }
}
```

**Aggregation**: is a "Has-a" relationship where a **whole has parts** **that belong to it**, There may be sharing of parts amount the wholes this relationship.

The "has-a" relationship from a whole to the parts is considered **weak "has-a"**. this means is although parts can belong to the wholes, they **can also exist independently** meaning they can **both exist without the other.**

for example relationship between airliner and its crew, so without the crew an airliner would not be able to fly, However, the airliner does not cease if there is no crew on board, same for the crew they are part of airliner but the crew become destroyed if they are not on board their airliner. the entities have a relationship but can exist outside of it. like relationship between course section and student, pet stores and pets, bookshelf and books.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/aggreg-ex.png" width="400" hight="400"/>
</p>

```csharp
public class Aireliner
{
    private List<CrewMember> Crew;

    public Aireliner()
    {
        Crew = new List<CrewMember>();
    }

    public void AddMember(CrewMember crewMember)
    {
        Crew.Add(crewMember);
        // Statements
    }
}

public class CrewMember
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Statements
}
```

**Composition:** is an exclusive containment of parts, otherwise known as a **strong "has-a"** relationship, this means is that the **whole cannot exist without its parts**, if it loses any of its parts the whole ceases to exist, if the whole destroyed then all of its parts are destroyed too. Usually you can only access the parts through its whole, Contained parts are exclusive to the whole, like the relationship between a house and a room, the human and brain.

**Composition is the most dependent of the decomposition relationships,** it forms relationship that only exists as long as each object exists.

The following diagram show class diagram of composition relationship, describes House object **has one or more** room objects.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/composition-ex.png" width="400" hight="400"/>
</p>

```csharp
public class Human
{
    public Brain Brain { get; set; }
    public Human()
    {
        Brain = new Brain();
    }
}

public class Brain
{
    // statements
}
```

### Generalization

Generalization helps reduce redundancy when solving problems.

When model behaviors using **methods** to eliminates the need to have identical code written throughout a program. like generalize repetitious code that we would need to write by making a separate method and calling it for examples

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/generlize-exp-1.png" width="300" hight="500"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/generlize-exp-2.png" width="300" hight="300"/>
</p>

**Generalization** is used when design algorithms, which are meant to be used to perform the same action on different sets of data, we generalize the actions into its own methods and simply pass the data through arguments.

**Generalization** also applied on class through **Inheritance,** so we take **repeated, common and shared characteristics** between two or more classes.

**Inheritance and Methods** exemplify the generalization design principle, that following technique called **Don't Repeat Yourself (D.R.Y)** which mean write programs that are capable of performing the same tasks but with less code to be more reusable and easy to maintain.

**Generalization UML Class diagram and C# Code example**

following figures shows how diagram inheritance in UML diagram and example 

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/generalization-ex1.png" width="300" hight="300"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/generalization-ex2.png" width="300" hight="300"/>
</p>

```csharp
public abstract class Animal
{
    protected int numberOfLegs;
    protected int numberOfTails;
    protected string name;

    public Animal(string petName, int legs, int tails)
    {
        this.name = petName;
        this.numberOfLegs = legs;
        this.numberOfTails = tails;
    }

    public virtual void walk() { /* statements */ } // to be overrided
    public void run() { /* statements */ }
    public void eat() { /* statements */ }
}

public class Dog: Animal
{
    public Dog(string name, int legs, int tails): base(name, legs, tails)
    { }

    public void playFetch() { /* statements */ }

		// you also can override a method in super class
		public override void walk() { /* statements */ }
}
```

**Multi-Inheritance**

Super class can have many sub classes, subclass can have only inherit from one superclass.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/multi-inher-ex.png" width="300" hight="300"/>
</p>

```csharp
public class Dog: Animal
{
    public Dog(string name, int legs, int tails): base(name, legs, tails)
    { }

    public void playFetch() { /* statements */ }
}

public class Cat: Animal
{
    public Cat(string name, int legs, int tails): base(name, legs, tails)
    { }

    public void playWithYarn() { /* statements */ }
}
```

**Generalization with Interfaces in C# and UML**

Interface is like a contract to be fulfilled by implementing classes, used to only describe behaviors.

- Interface like abstract classes which cannot be instantiated, which mean you can implement **polymorphism** meaning ****when two classes have the same description of behavior but implementation may be different
- Interface can inherit from other interfaces
- Interface inheritance should be abused, this mean you should not be extending interfaces if you trying to create larger interface
- C# and java does not support multi-inheritance classes because this cause **Data Ambiguity** meaning when subclass inherits from two or more with have the attributes with the same name or methods signature, how do we distinguish between them?
- So Class can implement as many interfaces as we want

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/interface-ex1.png" width="300" hight="300"/>
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/interface-ex2.png" width="300" hight="300"/>
</p>

```csharp
interface IAnimal
{
    public void move(); 
    public void speak(); 
    public void eat(); 
}

class Dog :IAnimal
{
    public void eat() { /* statements */}

    public void move() { /* statements */}

    public void speak() { Console.WriteLine("Bark!"); }
}

class Cat : IAnimal
{
    public void eat(){ /* statements */}

    public void move(){ /* statements */}

    public void speak() { Console.WriteLine("Meow!"); }
}
```

- Classes can implement on or more interface at time, which allows them to have multiple types.
- Interfaces enable you to describe behaviors without the need to implement them, which allows you to reuse these abstractions.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/class-vs-interface.png" width="400" hight="400"/>
</p>

### Evaluating Design Complexity

It is important to keep modules simple when you are programming,  If your design complexity which exceeds what developers can mentally handle, then bugs will occur more often.

To help control this we use **Module**

- Design complexity applies on both classes and methods so we use term called **Module** to refer to program unit containing classes and methods within them.
- **Coupling** focuses on complexity between a module and other modules.
- **Cohesion** focuses on complexity within a module.

## Coupling and Cohesion

this two concepts help to better apply of OOD principles and achieve more manageable system, A system is a combination of various modules. If the system has a **bad design,** then modules can **only** connect to other **specific** modules and **nothing else.** A **good design** allows **any** modules to connect together **without much trouble**. In other words, in a good design, modules are **compatible** with one another and can therefore be easily **connected and re-used**

### **Coupling**

**Coupling** for a module captures the complexity of connecting the module to other modules

- If your module **is highly reliant** on other modules, say this module is **tightly coupled** to others
- If your module finds **easy to connect** to other modules, say this module is **loosely coupled** to others, So it's important for you module to be **loose** or low not tight.

When evaluating the Coupling of module you need to consider metrics **degree**, **ease**, and **flexibility**

- **Degree** is the number of **connections** between the module and others. With coupling, you want to keep the degree **small**, For instance if the module needed to connect to other modules through a **few parameters or narrow interfaces,** then the degree would be small and coupling would be loose.
- **Ease** is **how obvious** are the connections between the module and others. With coupling, you want the connections to **be easy to make** without needing to understand the implementations of the other modules.
- **Flexibility** is how interchangeable the other modules are for this module. With coupling, you want the other modules **easily replaceable** **for something better** in the future.

### Cohesion

Cohesion represents the clarity of the responsibilities of a module.

- If your module performs **one task and nothing else** or has a clear purpose, you module has **high cohesion**
- If you module tries to encapsulate **more than one purpose** or has an unclear purpose, you module has **low cohesion**.

A bad design has low cohesion, if a module has more than one responsibility, it is a good idea to **split** the module.

**For example** suppose you have class called **Sensor** that has **two purposes,** getting humidity and get temperature

```csharp
class Sensore
{
    public float Humidity { get; set; }
    public float Temperature { get; set; }

    public float get(int controlFlag)
    {
        switch (controlFlag)
        {
            case 0:
                return this.Humidity;
                break;
            case 1:
                return this.Temperature;
                break;
            default:
                throw new Exception("Unknown Control Flag");
        }
    }
}
```

Since the sensor class doesn't have a clear single purpose so it have **Low Cohesion**

Since it's unclear what controlFlag means until to read inside the method itself in order to know what values to give it which lacks ease to make the get method harder to use which call **Tightly Coupled**

To make it **loosely coupled and high cohesion** follow new design which split it to two classes each one has one purpose, and not hiding any information we don't need to break encapsulation to look inside the method

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/couped-ex.png" width="400" hight="400"/>
</p>

It is important to balance between **low coupling and high cohesion** in system design. Both are necessary for a good design.

For complex system can be distributed between the modules or within the modules

- As modules are simplified to achieve **high cohesion**, they may need to depend more on other modules thus **increase coupling.**
- As connections between modules are simplified to achieve **low coupling**, they may to need to take more responsibilities thus **lowering cohesion**

### **Separation of Concerns**

Is an ongoing process throughout the design process.

**Concern** is a very general notion, basically it is anything that matters in providing a solution to a problem, Which is a key idea that applies throughout object oriented modelling and programming.

Consider a software system that solves a problem. That problem could either be simple, with a small number of subproblems, or complex, with a large number of subproblems. Concepts can be abstracted from the problem space. When these abstractions are implemented in the software, it can lead to more concerns

How these abstractions are implemented in the software can lead to more concerns? Some of these concerns may involve:

- What information the implementation represents
- What it manipulates
- What gets presented at the end

Importance of separation of concerns:

- They allow you to develop and update sections of the software independently.
- Using separation of concerns also means that you do not need to know how all sections of code work in order to update a section.
- It allows changes to be made to one component without requiring a change in another.

The concerns that matter are addressed separately when applying the design principles of **abstraction, encapsulation, decomposition, and generalization**

⇒ each concept in the problem space leads to separate **abstraction** with its own relevant attributes and behaviors, these attribute and behaviors are **encapsulated** into their own section of code called class, The view of a class by the rest of the system and its implementation are separated, so that the details of implementation can change while the view through an interface can stay the same, A whole class can also be **decomposed** into multiple classes, we may recognize commonalities among classes which are then separated and **generalized** into a super class.

**For example The Smartphone** which focus on two functionality of using camera and make calls

```csharp
public class SmartPhone
{
    private byte camera;
    private byte phone;

    public SmartPhone() { … }

    public void takePhoto() { … }
    public void savePhoto() { … }
    public void cameraFlash() { … }

    public void makePhoneCall() { … }
    public void encryptOutgoingSound() { … }
    public void decipherIncomingSound() { … }
}
```

This code is **low cohesion** in SmartPhone class, because we have behaviors that are not related to each other, the camera behaviors don't need to be encapsulated with the behaviors of the phone for the camera to do its job, In addition don't offer any **modularity**, We cannot access the camera or the phone separately if we were to build another system that required only one, and we cannot replace our current camera with a different camera/different object.

So to make this class more cohesive and give each component distinctive functionalities!

Just check what our class is concerned about and separate them out, for example SmartPhone has two concerns

- Act as a tradition phone
- Be able to use the built-in camera to take pictures

So after applied separation of concerns

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/seperation-of-concerns.png" width="400" hight="400"/>
</p>

```csharp
public interface ICamera 
{
	public void takePhoto();
	public void savePhoto();
	public void cameraFlash();
}

public interface IPhone
{
    public void makePhoneCall();
    public void encryptOutgoingSound();
    public void deciphereIncomingSound();
}
public class FirstGenCamera: ICamera
{
    /* Abstracted camera attributes */
}
public class TraditionalPhone : IPhone
{
    /* Abstracted phone attributes */
}

public class SmartPhone
{
    private ICamera myCamera;
    private IPhone myPhone;

    public SmartPhone(ICamera aCamera, IPhone aPhone)
    {
        this.myCamera = aCamera;
        this.myPhone = aPhone;
    }

    public void useCamera()
    {
        this.myCamera.takePhoto();
    }
    public void usePhone()
    {
        this.myPhone.makePhoneCall();
    }
}
```

So now if we want change or swap out the camera or phone classes for something else, we don't need to touch any of the SmartPhone class's code, we just change the code to it's parts.

We used separation of concerns throughout this example by separating out the general notions of camera and phone through applying **generalization** and defining two interfaces, separating out the functionality for a FirstGenCamera and TraditionalPhone by applying **abstraction** and **encapsulation**, finally by applying **decomposition** to the smartphone so the parts are separated from the whole. by applying this the code will be organized so that it only contains the code that needs it do its job

## Information Hiding

One important thing is How to address information access? You don't need everything in your system to know about everything else. The Module should only have access to the information that it needs to do its job, we do this by applying **information hiding**

Information hiding allows modules of our system to give others the minimum amount of information needed to use them correctly and "hide" everything else. which enable developer working on a module separately without other developers needing to know the implementation details. They can use it through interface.

In general things that might change like **implementation details,** should be **hidden**. And things that should not change like **assumptions** are revealed through **interfaces.**

**Information Hiding Through Encapsulation:** we use encapsulation to bundle attributes and behaviors into their appropriate class, and expose an interface to provide access. which allows:

- Hide implementation of behaviors and only access through an interface of specific methods, So other classes rely on the information in these method signatures not the implementation
- Change the implementation without changing the expected outcome

So you can hide information through the use of **Access Modifiers** which C# have 4 different levels of access **Public**, **Protected**, **Private**, and **Internal**

- **Attributes** with a **public** access modifier are accessible by **any class** in your system which mean other classes can retrieve and modify the attribute. **Public Methods** are also accessible by any class in your system, but does not allow other classes to **change the implementation** of the behavior for the method, just other classes call the method and receive any output.
- **Protected** Methods and Attributes are not accessible to every class in the system, the are only available to the encapsulating **class itself, all subclasses, and within the same package/namespace**
- **Internal** Modifier The code is only accessible within its own assembly, but not from another assembly
- **Private** Attributes and methods are **not accessible** by any class other than by the **encapsulating class itself,** This mean these attributes cannot be accessed directly and these methods cannot be invoked by another classes.

### Conceptual Integrity

It about creating consistent software, making decision about how your system will be designed and implemented, so if you see multiple people working on software it would seem as only on mind guiding all the work.

**Conceptual integrity** does not mean that the developers in your team don't get to voice their opinions about the software, It's more about **everyone agreeing** to use certain design principles and conventions.

You can achieve Conceptual integrity through:

- **Communication** through adopting agile development practices like **Daily Stand-Up Meetings** and **sprint retrospectives** where team members agree to use certain libraries or methods when addressing certain issues, For example team members can all follow a particular **naming convention**
- **Code Reviews** which are systematic examinations of written code like peer review in writing, which used to **find mistakes** in the software and keep different developers consistent with each other, Developers go through code line by line and uncover issues in each other’s code.
- Using **Design Principles** and **Design Patterns**
- Having a **well-defined design or architecture** underlying the software, While software design is  associated with guiding internal design of process running as a single process, Software Architectures describe how software running as multiple processes work together which creates organized software consistency.
- **Unifying concepts** is taking different concepts and finding a commonality, For example in the Unix OS every resource can be seen and manipulated as file, the same set of operations can be used on different types of resources.
- Having a **small group** that accepts commits to the code base, which similar to code reviews but restricts the reviews to only members of your software team to ensure the software changes follow the overall architecture and design of the software to solve any design issues and lead to consistency.

### Inheritance Issues

Inheritance is a powerful design tool that can help you create clean, reusable and maintainable software systems. But **misusing** inheritance can lead to **poor code** and that happen when creating **more problems** than they are meant to solve. 

To know that you:

- Ask yourself: "Am I using inheritance to simply share attributes or behaviors without further adding anything **special in my subclasses**?"
- If the **Liskov Substitution Principle** are broken, which this principle states that a subclass can replace a superclass, if and only if the subclass does not change the functionality of superclass.

Example for bad inheritance in java, In Stack data structure, the Java Stack class inherits from a Vector superclass. This means that the Stack class is able to return an element at a specified index, retrieve the index of an element, and even insert an element into a specific index. These are not behaviors normally expected from a stack.

**If inheritance does not suit your need**, Just using **decomposition** will be more appropriate.

For SmartPhone Example

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/smartphone-ex1.png" width="300" hight="300"/>
</p>

which are not make sense for SmartPhone to inherit from the phone and then add camera methods to it. So in this case we should use decomposition to extract out the camera responsibilities and put it into their own class like this:

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/smartphone-ex2.png" width="400" hight="400"/>
</p>

Inheritance could be a difficult design principle to apply, but still a very powerful technique.

### UML Sequence Diagrams

Sequence diagram are used to show your team how **objects** in your program **interact** with each other to complete tasks. Thing it as mapping of conversation from two people/objects, it used as a planning tool before the dev team start coding to help determining the functions you will need.

**For example** a person wants to order a burger at local fast food restaurant,

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/UMLSequence-ex1.png" width="700" hight="700"/>
</p>

**Components of Sequence Diagram**

- **Boxes** are used to represent a role played by an object. The **role** is typically named after the class for the object
- **Vertical dotted lines** known as **lifelines** to represent an object as time passes by.
- **Solid line Arrows** to show **messages** that are sent from one object to another. A short description of the message is usually included above the arrow
- **Dotted line arrows** are used to show a return of data and control back to initiating objects.
- **Small rectangles** along an object’s lifeline denote a **method activation**. You activate an object whenever an object sends, receives, or is waiting for a message.

Sequence diagrams are typically framed within a large box which show that this is **one** sequence of activities, Also Sequence diagram can contain **other sequence diagrams** within it

**For example** in changing the channel of TV by using remote control.

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/UMLSequence-ex2.png" width="700" hight="700"/>
</p>

When sequence diagrams get more complicated, you can also show **Loops** and **Alternative** processes in sequence diagram, for above example when Viewer is unsure what channel to go to. and would like to surf the channels until find a channel they like 

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/UMLSequence-ex3.png" width="700" hight="700"/>
</p>

### UML State Diagram

**A State Diagram** is a technique that you can use to describe how your system behaves and responds. When an event occurs you note how a system acts or behaves and show changes between states to determine the different events that might occur during object's lifetime like user inputs, and how this object behave when this event occurs like checking conditions and performing actions.

**State diagrams** can describe a single object and illustrate how that object behaves in response to a series of events in your system by imaging the changing states of object. Also help finding an issues in your system like discovering a condition that didn't play for or help to create tests.

**State** is the way an object exists at particular point in time, The state of an object is determined by the values of its attributes.

**For example** Car with automatic transmission can have different states like park, reverse, neutral, and drive. When a car is in reverse it can only behave move backwards, if you want it to move a forwards direction you have to change the state of car.

UML State Diagram components

- **Filled circle** to indicate the **start state** of diagram.
- **Arrows** are used to represent **events** to **transition** from one state to another
- **Rounded rectangles** indicate other states which have three sections a **state name**, **state variables**, and **activities**
    - **State name** is the name of the state, it should be meaningful for the states of your object
    - **State Variables** are data relevant to the state of the object
    - **Activities** are actions that are performed in the state, There are three types for each state, **entry, exit and do**
        - **Entry** activities are actions that occur when the state is **just entered** from another state
        - **Exit** activities are actions that occur when the state **is exited** and moves on to another.
        - **Do** activities are actions that occur **once, or multiple times**
- **Termination** represents an object being **destroyed** or the process being **completed**

**Example** of Vending machine 

<p align="center" width="100%">
  <img src="https://github.com/aboelkassem/Design-Patterns/blob/main/OOD/images/UMLState-ex.png" width="700" hight="700"/>
</p>

### Model Checking

After using many techniques to design your system, **How do you make sure that the system you've created is correct**? you can run **tests** and see if the actual behavior matches what you expect, another technique is **model checking**

**Model checking** is a systematic **check** of your system's state model, you **check all the states** of your software and find that there are any **errors** by simulating different events that change the states and variables of your software. And notifies you of any violations of the rules.

Model checks are performed by **model checking software**. There are different types of software available for such **tests**, some of which are free and available for developers using different languages. Model checking is typically performed during **testing** of the software

Think of model checking like going through airport security, Security guards in airports know the rules of what people should have or shouldn't have to get on an airplane.

Imagine software that has a rule not to produce a **deadlock, Deadlock** is a situation where your system **cannot continue** because **two tasks are waiting for the same resource.** So your **model checker** would simulate the different states that could occur in your system and if **deadlock** is possible, it would provide you details of the violation.

**How do you model check your software** ? Model checkers generate a **State Model** from your code, A state model is an abstract state machine that can be in one of various states, the model checker then checks the state of model conforms to behavioral properties. For example, the model checker can examine the state model for flaws like **race conditions**, exploring all the possible states of your model.

The three different phases to performing model checking :

- **The Modeling phase**: where you enter **model description** in whatever programming language your system uses, describe the desired properties.
- **The Running phase:** this is when you **run the model checker** to see how your model confirms to the desired properties that you've wrote in the modeling phase.
- **The Analysis phase**: this is when you **check** if all the desired properties are satisfied and if any are violated (Counterexamples), proving information to you where to fix any problems.

Model checking helps ensure not only that software is well designed, but also that software meets desired properties and behavior, and it works as intended. There are also many ways to test your system's behaviors like **unit testing**, beta testing and simulations
