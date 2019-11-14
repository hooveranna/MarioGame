CA1002:
Warning	CA1002	Change 'List<Texture2D>' in 'ParticleEngine.ParticleEngine(List<Texture2D>, Vector2)' to use Collection<T>, ReadOnlyCollection<T> or KeyedCollection<K,V>	Sprint 4	C:\Users\flash\Source\Repos\Team Gamers Rise Up Sprint 4\Sprint 2\Particles\ParticleEngine.cs	20	Active
Can't change List to Map or different collection because that would require changing the entire particle engine and the corresponding class.

All Camera related Issues that we didnt write are ignored.

CA1823:
Warning	CA1823	It appears that field 'InvisibleWall.position' is never used or is only ever assigned to. Use this field or remove it.	Sprint 4	C:\Users\prave\Source\Repos\Team Gamers Rise Up Sprint 4\Sprint 2\Collision\InvisibleWall.cs	13	Active
We are planning on using the position to fix some of our collision response issues. We aren't sure how yet.

CA1823:
Warning	CA1823	It appears that field 'InvisibleWall.vertical' is never used or is only ever assigned to. Use this field or remove it.	Sprint 4	C:\Users\prave\Source\Repos\Team Gamers Rise Up Sprint 4\Sprint 2\Collision\InvisibleWall.cs	14	Active
The Vertical variable would be necessary when determining vertical collision. We plan on using this variable to fix vertical collision issues.

CA1033
Warning	CA1033	Make 'InvisibleWall' sealed (a breaking change if this class has previously shipped), implement the method non-explicitly, or implement a new method that exposes the functionality of 'ICollidable.BoundingBox.get()' and is visible to derived classes.	Sprint 4	C:\Users\prave\Source\Repos\Team Gamers Rise Up Sprint 4\Sprint 2\Collision\InvisibleWall.cs	39	Active
This change would mean we would have to refactor our entire InvisibleWall class. For now, we do not have enough time to do so.

CA1812
Warning	CA1812	'EnemyMoveLeft' is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static methods, consider adding a private constructor to prevent the compiler from generating a default constructor.	Sprint 4	C:\Users\prave\Source\Repos\Team Gamers Rise Up Sprint 4\Sprint 2\Commands\ItemAndEnemyCommands.cs	10	Active
We are only using these commands to test our code. We aren't planning on using this in the full release.

CA1811
Warning	CA1811	'SuperStarModel.MoveAway()' appears to have no upstream public or protected callers.	Sprint 4	C:\Users\prave\Source\Repos\Team Gamers Rise Up Sprint 4\Sprint 2\Models\ItemModels\SuperStarModel.cs	88	Active
We plan on using the MoveAway method to clean up SuperStarModel movement. We don't have enough time right now to fully implement it yet.

