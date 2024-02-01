import React, { useEffect, useState } from 'react';
import { getDocumentTypes, uploadDocument, getDocuments } from './api';
import './App.css';
import DocumentList from './DocumentList';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import DocumentForm from './DocumentForm';
import './DocumentForm.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container, Row, Col } from 'reactstrap';

function App() {
  const [documentTypes, setDocumentTypes] = useState([]);
  const [uploadedFiles, setUploadedFiles] = useState([]);
  const [documents, setDocuments] = useState([]);

  useEffect(() => {
    const fetchDocumentTypes = async () => {
      try {
        const types = await getDocumentTypes();
        setDocumentTypes(types);
      } catch (error) {
        console.error('Error fetching document types:', error);
      }
    };

    fetchDocumentTypes();
  }, []);

  const handleDocumentUpload = async (document) => {
    try {
      const uploaded = await uploadDocument(document);
      setUploadedFiles((prevFiles) => [...prevFiles, ...uploaded]);
    } catch (error) {
      console.error('Error uploading documents:', error);
    }
  };

  const fetchDocuments = async () => {
    try {
      const response = await getDocuments();
      console.log(response)
      setDocuments(response);
    } catch (error) {
      console.error('Error fetching documents:', error);
    }
  };

  return (

    <div>
      <h1>Document App</h1>
      <Container>
        <Row>
          <Col
            className="bg-light border"
            xs="6"
          >
            <h2>Available Document Types:</h2>
            <ul>
              {documentTypes.map((type) => (
                <li key={type}>{type}</li>
              ))}
            </ul>
          </Col>
          <Col
            className="bg-light border"
            xs="6"
          >
            <div className="app-container">
              <DocumentForm onUpload={handleDocumentUpload} onListRefresh={fetchDocuments} />
            </div>
          </Col>
        </Row>
        <Row>
          <Col className="bg-light border">
            <Router>
              <Routes>
                <Route path="/" element={<DocumentList onListRefresh={fetchDocuments} />} />
              </Routes>
            </Router>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default App;
