Gilded Rose Requirements Specification
======================================

This Kata was clone from Gilded Rose Kata from this link https://github.com/emilybache/GildedRose-Refactoring-Kata/tree/master/csharp.

My Approach
======================================

- First of all, to make sure I won't break any business while refactoring, I've written a bunch of unit tests in the file 'GildedRoseTest.cs'
and check that all of them passed before I start making any changes to the code.
- Secondly, I use Dependency Injection to write handlers for each type of Item in file 'IHandler.cs'.
- Thirdly, I make changes in the function 'UpdateQuality' in file 'GildedRose.cs' to call corresponding handler based on item's name.

How to use this Kata
======================================

In the file 'GildedRose.cs', I still keep old function 'UpdateQuality' commented. Besides checking the logic of unit tests, you can run unit tests with this old function to make sure everything look good.
Afterwards, you can start using the new function 'UpdateQuality' refactored by me along with unit tests.
