# Automation Playbook

Version: 1.0

Author: Denis Tolochanov with AI

---

# Purpose

Automation Playbook describes standards, architecture and best practices for building UI and API automation frameworks in C#/.NET.

The goal of this document is:

- build clean and scalable automation frameworks;
- follow a single coding style;
- simplify code reviews;
- allow AI assistants to generate code using the same standards;
- keep all projects consistent.

---

# Core Principles

The framework should always be:

- readable;
- maintainable;
- scalable;
- reusable;
- easy to understand.

Code is written for people first and only then for the compiler.

# Project Structure

Each folder in the project has one responsibility only.

The project is divided into logical layers.

Tests          -> test scenarios

Pages          -> UI interaction

Clients        -> API interaction

Builders       -> complex object creation

Models         -> request and response models

TestData       -> test constants and predefined values

Core           -> shared infrastructure

Configuration  -> URLs, endpoints and settings