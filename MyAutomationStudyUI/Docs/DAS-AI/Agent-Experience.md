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