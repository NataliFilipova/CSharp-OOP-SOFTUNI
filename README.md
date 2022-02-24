# CSharp-OOP-SOFTUNI

<b>Superclass</b> - Perent class, Base class.
- The class giving its members to its child class.

<b>Subclass</b> - Child class, Derived class.
- The class taking members from its base class.

```diff
- CONSTRUCTORS ARE NOT INHERITED!
```

- Derived classes can access all public and protected members, internal too.

- Private firelds are inherited, but not visible in subclasses.

```diff
- Virtual difenes a method that can be overriden.
```
public <b> virtual </b> void Eat ()
{
  ...
}
 - will be overriden by the child 

<b> Sealed Modifier </b> - The sealed modifirer prevents other classes from inheriting from it. 
- it can be used on a method or a property in a base class

- It enables you to allow classes to derive from your class

- Prevents the overriding of specific virtual methods and
properties
