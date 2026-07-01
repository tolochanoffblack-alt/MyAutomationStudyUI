# Agent Experience

Version: 1.0

---

## EXP-001 — RestSharp Successful Response Validation

When validating successful RestSharp API responses, prefer checking both:

- response.IsSuccessful
- expected HTTP status code

Example:

Assert.That(response.IsSuccessful, Is.True);
Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));