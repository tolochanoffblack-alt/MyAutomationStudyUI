# Project Knowledge

Version: 1.0

---

# Project Overview

This project is a C#/.NET automation framework.

The framework contains UI automation and API automation.

The project is intended to demonstrate production-quality automation engineering.

Architecture consistency has higher priority than implementation speed.

---

# Technology Stack

Language

- C#

Framework

- .NET 10
- NUnit

API

- RestSharp

UI

- Selenium WebDriver

Patterns

- Page Object Model
- Builder Pattern

Assertions

- NUnit Assert.That

Version Control

- Git

CI/CD

- GitHub Actions

---

# Project Architecture

Current architecture contains:

Core

Shared infrastructure.

Configuration

URLs, endpoints and environment configuration.

Builders

Construction of reusable request objects.

Models

Request and response DTOs.

Clients

API communication.

Pages

UI interaction.

Tests

Business scenarios.

TestData

Reusable test values.

---

# API Standards

API communication is performed only through Client classes.

Every endpoint has its own Client method.

All request execution goes through BaseApiClient.

Tests never create RestRequest directly.

Tests never know endpoint URLs.

HTTP status codes are treated as business results.

Network failures are handled inside BaseApiClient.

Assertions exist only inside tests.

---

# UI Standards

Page Object Model is mandatory.

Tests never contain:

- XPath
- CSS selectors
- Selenium locators
- WebDriver interaction

Locators are private.

Actions are public.

Shared functionality belongs to BasePage.

Thread.Sleep() is prohibited.

---

# Test Standards

Arrange / Act / Assert is mandatory.

Assert.That is mandatory.

One test verifies one logical behavior.

Tests describe business scenarios.

Tests do not contain implementation details.

---

# Builder Standards

Builders are used for reusable or complex request objects.

Builder methods return this.

Builders contain Build().

Builders do not execute requests.

Builders do not contain assertions.

---

# TestData Standards

Reusable values belong to TestData.

Examples:

- IDs
- usernames
- passwords
- expected values
- reusable request values

Tests should contain as little hardcoded data as possible.

---

# Naming Standards

Classes

PascalCase

Methods

PascalCase

Properties

PascalCase

Private fields

_camelCase

Test names

Action_Condition_ExpectedResult

---

# Architecture Priorities

Priority 1

Preserve architecture.

Priority 2

Reuse existing implementation.

Priority 3

Avoid duplication.

Priority 4

Generate production-ready code.

Priority 5

Keep implementations simple.

---

# Existing Framework Components

The framework already contains:

- BaseApiClient
- BasePage
- JsonPlaceholderClient
- JsonPlaceholderTestData
- Builders
- API Models
- Page Objects
- NUnit tests
- GitHub Actions pipeline

The agent should always reuse these components before creating new ones.

---

# Forbidden Practices

Never:

- create duplicate Clients;
- create duplicate Builders;
- create duplicate Models;
- create duplicate Page Objects;
- create duplicate TestData;
- hardcode reusable values;
- hardcode endpoints;
- use RestRequest inside tests;
- use Selenium locators inside tests;
- use Thread.Sleep();
- introduce new architecture without approval.

---

# Project Goal

Every generated change should make the framework more maintainable, more consistent and easier to extend.

The framework should always evolve without increasing technical debt.