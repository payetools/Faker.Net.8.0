# Faker.Net.8.0

.NET 8.0-compatible C# port of the Ruby Faker gem (http://faker.rubyforge.org/) and is used to easily generate fake data:

	addresses (UK, US),
	boolean,
	companies,
	countries,
	currencies,
	enums,
	finance (isin, ticker, coupon, maturity, bond name),
	identification (social security number (US), MBI (US), national insurance number (UK), passport number (UK & US), Bulgarian Person Identification Number(PIN/ENG))
	internet (email, domain names, user names),
	lorem ipsum,
	names,
	phone numbers

Available as a NuGet package (https://nuget.org/packages/Faker.Net.8.0).

Get the code via git:

    git clone git://github.com/payetools/faker-cs-8-0.git

(The original faker-cs repo is at git://github.com/oriches/faker-cs but that repo only supports .NET versions up to .NET 6.0)

Example code 
```CSharp
var name = Faker.Name.FullName(); // Tod Yundt
var firstName = Faker.Name.First(); // Orlando
var lastName = Faker.Name.Last(); // Brekke
var address = Faker.Address.StreetAddress(); // 713 Pfeffer Bridge
var city = Faker.Address.City(); // Reynaton
var number = Faker.RandomNumber.Next(100); // 30
var dob = Faker.Identification.DateOfBirth(); // 1971-11-16T00:00:00.0000000Z

// US - United States
var ssn = Faker.Identification.SocialSecurityNumber(); // 249-17-9666
var mbi = Faker.Identification.MedicareBeneficiaryIdentifier(); // 8NK0Q74KT53
var usPassport = Faker.Identification.UsPassportNumber(); // 335587506

// UK - United Kingdom
var nin = Faker.Identification.UkNationalInsuranceNumber(); // YA171053Y
var ninFormatted = Faker.Identification.UkNationalInsuranceNumber(true); // YA 17 10 53 Y
var ukPassport = Faker.Identification.UkPassportNumber(); // 496675685
var ukNhs = Faker.Identification.UkNhsNumber(); // 6584168301
var ukNhsFormatted = Faker.Identification.UkNhsNumber(true); // 658 416 8301

// BG - Bulgaria
var bulgarianPin = Faker.Identification.BulgarianPin(); //6402142606
```

Supported .NET versions:	.NET 8.0 only