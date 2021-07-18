import React from "react"
import { BrowserRouter, Route} from "react-router-dom";
import LoginForm from "../Components/Pages/LoginForm"
import { render, fireEvent } from "@testing-library/react"
import "@testing-library/jest-dom/extend-expect"

test("header Easy Room render inside login page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const headerEl = component.getByTestId("ProductHeader1")

    expect(headerEl.textContent).toBe("Easy Room")
})

test("header detail render in login page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const headerEl = component.getByTestId("ProductHeader2")

    expect(headerEl.textContent).toBe("Enjoy our free online Chat App")
})

test("Product paragraph render in login page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const headerEl = component.getByTestId("ProductParagraph")

    expect(headerEl.textContent).toBe("Fast, Secure and Forever free")
})

test("Greating header render in login page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const headerEl = component.getByTestId("GreatingHeader")

    expect(headerEl.textContent).toBe("Welcome Back!")
})

test("Login Paragraphe render in login page", async () => 
{
    const component = render(
        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const headerEl = component.getByTestId("LoginParagraph")

    expect(headerEl.textContent).toBe("Sign into your account")
})

test("Username textbox initally start with empity value", async () =>
{
    const component = render(

        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const inputEl = component.getByTestId("UsernameInput")
    expect(inputEl.value).toBe("");
})

test("Password textbox initally start with empity value", async () =>
{
    const component = render(

        <BrowserRouter>
            <Route component={LoginForm} />
        </BrowserRouter>
    )
    const inputEl = component.getByTestId("PasswordInput")
    expect(inputEl.value).toBe("");
})
