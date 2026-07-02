# Agent Experience

Version: 1.0

---

## EXP-001

Context

New or modified RestSharp API tests.

Rule

When validating successful RestSharp responses, prefer validating both:

- response.IsSuccessful
- expected HTTP status code

Scope

Apply this rule only to:

- newly created tests;
- tests modified as part of the current task.

Do not refactor unrelated tests unless explicitly requested.

Reason

Keeps changes focused on the requested feature while improving test quality.

---

## EXP-002

Context

API request models and builders.

Rule

Before creating a new request model or builder, verify whether an existing one can be safely reused.

Scope

Apply when request payloads have the same structure or when an existing builder already supports the required fields.

Do not create semantically different models or builders without a clear business or technical reason.

Reason

Avoids unnecessary duplication and keeps the framework simple and maintainable.

---

## EXP-003

Context

Using artifacts produced by another agent.

Rule

Artifacts from other agents should be treated as verified observations, not final implementation decisions.

Scope

Apply when Developer Agent uses reports from UI Inspector, API Inspector, Security Inspector, or any other specialized agent.

The Developer Agent must still validate architectural decisions against the existing project.

Do not blindly accept recommendations from another agent.

Reason

Specialized agents provide facts and findings. The Developer Agent is responsible for final engineering decisions and implementation design.