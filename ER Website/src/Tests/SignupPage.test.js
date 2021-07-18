import React from "react"
import { BrowserRouter, Route} from "react-router-dom";
import SignupForm from "../Components/Pages/SignUpForm"
import { render} from "@testing-library/react"
import "@testing-library/jest-dom/extend-expect"

test("Product name render inside signup page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )
    const productNameEl = component.getByTestId("ProductName")

    expect(productNameEl.textContent).toBe("Easy Room")
})

test("Product detail render inside signup page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )
    const productExpEl = component.getByTestId("ProductExp")
    
    const detailTxt = "Easy Room is a gamer networking site that makes it easy for you to connect and share with your friends online."

    expect(productExpEl.textContent).toBe(detailTxt)
})

test("Create Accout paragraph render inside signup page", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )
    const accountParagraphEl = component.getByTestId("AccountP")

    expect(accountParagraphEl.textContent).toBe("Welcome to Easy Room!")
})

test("Firstname input box render and initial with empity value", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const inputEl = component.getByTestId("FirstnameInput")
    expect(inputEl.value).toBe("");
})

test("Lastname input box render and initial with empity value", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const inputEl = component.getByTestId("LastnameInput")
    expect(inputEl.value).toBe("");
})

test("Email input box render and initial with empity value", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const inputEl = component.getByTestId("EmailInput")
    expect(inputEl.value).toBe("");
})

test("Username input box render and initial with empity value", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const inputEl = component.getByTestId("UsernameInput")
    expect(inputEl.value).toBe("");
})

test("Password input box render and initial with empity value", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const inputEl = component.getByTestId("PasswordInput")
    expect(inputEl.value).toBe("");
})

test("Second password input box render and initial with empity value", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const inputEl = component.getByTestId("ConfirmPassInput")
    expect(inputEl.value).toBe("");
})

test("Login link paragraph renderd in signup page", async () =>
{
    const component = render(
        <BrowserRouter>
            <Route component={SignupForm} />
        </BrowserRouter>
    )

    const loginPEl = component.getByTestId("LoginLinkText")
    expect(loginPEl.textContent).toBe("Already have an account ? ");
})