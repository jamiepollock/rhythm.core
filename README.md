# Introduction

Provides basic functionality used by other Rhythm libraries.

Include some string extension methods and some collection extension methods.

Refer to the [generated documentation](docs/generated.md) for more details.

# Installation

Install with NuGet. Search for "Rhythm.Core".

# Overview

Collection extension methods:

* **AsList** Returns the supplied collection as a list. Differs from ToList in that it will return the original collection if it is already a list, and it will never return null.
* **MakeSafe** Returns a non-null version of the collection.
* **RandomOrder** Returns a collection with the elements of the supplied collection in a random order.
* **Repeat** Creates a collection of the specified size with each element containing the same item.
* **WithoutNulls** Returns the collection without null items.

NameValueCollection extension methods:

* **GetBooleanValue** For a given key, attempts to return a `boolean` or fallback value.
* **GetEnumValue** for a given key, attempts to return a `enum` or fallback value.
* **GetEnumValueIgnoreCase** for a given key, attempts to return a `enum` or fallback value ignoring the case of the found value.
* **GetIntegerValue** for a given key, attempts to return an `integer` or fallback value. Optional overload with `NumberStyles` and `IFormatter` parameters.
* **GetStringValue** for a given key, attempts tp return a `string` or fallback value.
* **GetSplitStringValues** for a given key, attempts to return a split `string` as a `IEnumerable<string>` or fallback value.
* **HasKey** checks if a given key exists, returning a `boolean`.
* **TryGetValue** checks if a value exists in the collection for a given key. Returns a `boolean` depending on success, also returns a string as an output value.
* **TryGetValues** checks if values exist in the collection for a given key. Returns a `boolean` depending on success, also returns a `IEnumerable<string>` as an output value.

String extension methods:

* **SplitBy** Splits a string by the specified delimiters.
* **ToSnakeCase** Converts a camel case string to snake case.
* **SanitizeForCss** Converts a string for use as a CSS class.

# Maintainers

To create a new release to NuGet, see the [NuGet documentation](docs/nuget.md).