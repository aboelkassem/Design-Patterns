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
