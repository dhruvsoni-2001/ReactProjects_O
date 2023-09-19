import logo from "./logo.svg";
import Table from "react-bootstrap/Table";
import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import InputGroup from "react-bootstrap/InputGroup";
import 'bootstrap/dist/css/bootstrap.css';
import { data } from "./Data.js";
import { useState } from "react";

function App() {
  const [contacts, setContacts] = useState(data);
  const [search, setSearch] = useState("");

  return (
    <div>
      <Container>
        <h1 className="text-center mt-4">Contact Keeper</h1>
        <Form>
          <InputGroup className="my-3">
            {/* on Change Search  */}
            <Form.Control
              onChange={(e) => setSearch(e.target.value)}
              placeholder="Search Contacts"
            />
          </InputGroup>
        </Form>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email</th>
              <th>Phone</th>
            </tr>
          </thead>
          <tbody>
            {data
              .filter((item) => {
                return search.toString() === ""
                  ? item
                  : item.first_name.toString().includes(search);
              })
              .map((item, index) => (
                <tr key={index}>
                  <td>{item.first_name}</td>
                  <td>{item.last_name}</td>
                  <td>{item.email}</td>
                  <td>{item.phone}</td>
                </tr>
              ))}
          </tbody>
        </Table>
      </Container>
    </div>
  );
}

export default App;
