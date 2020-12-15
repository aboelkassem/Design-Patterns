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
