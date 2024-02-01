import React, { useEffect, useState } from 'react';
import { baseURL, getDocuments, shareDocument } from './api';
import './DocumentList.css';
import { Table, Button, Alert } from 'reactstrap';
import moment from 'moment';
import copy from 'clipboard-copy';


const DocumentList = ({ onListRefresh }) => {
  const [documents, setDocuments] = useState([]);
  const [shareLink, setShareLink] = useState('');

  const fetchShareLink = async (document) => {
    try {
      // setLoading(true);
      
      const data = await shareDocument(document);
      
      setShareLink(data.data);
    } catch (error) {
      console.error('Error fetching share link:', error.message);
    } finally {
      // setLoading(false);
    }
  };

  const copyToClipboard = (link) => {
    copy(link);
    alert('Text copied to clipboard!');
  };

  const doDownload = async (document) => {

    const updatedItems = documents.map((item) =>
      item.id === document.id ? { ...item, downloads: item.downloads + 1 } : item
    );

    window.open(`${baseURL}/documents/download/${document.id}`)

    setDocuments(updatedItems);
  };

  useEffect(() => {
    const fetchDocuments = async () => {
      try {
        const response = await getDocuments();
        setDocuments(response);
      } catch (error) {
        console.error('Error fetching documents:', error);
      }
    };

    fetchDocuments();
  }, [onListRefresh]);

  return (
    <div>
      <h1>Document List</h1>

      {
        shareLink && (
          <div>
            <Alert>
              Share Link: {' '}
              <a
                className="alert-link"
                rel="noreferrer"
                style={{ cursor: 'pointer' }}
                onClick={() => copyToClipboard(shareLink)}
              >
                {shareLink}
              </a>
              . Give it a click to copy.
            </Alert>
          </div>
        )
      }

      <Table
      >
        <thead>
          <tr>
            <th>
              #
            </th>
            <th>
              Icon
            </th>
            <th>
              Name
            </th>
            <th>
              Upload Time
            </th>
            <th>
              Downloads
            </th>
            <th>
              Actions
            </th>
          </tr>
        </thead>
        <tbody>
          {
            documents.map((document, index) => (
              <tr key={document.id}>
                <th scope="row">
                  {index + 1}
                </th>
                <td>
                  <img style={{ width: '25px', height: '25px' }} src={`${baseURL}/icons/${document.documentType.icon}`} alt={document.documentType.name} />
                </td>
                <td>
                  {document.name}
                </td>
                <td>
                  {moment(document.createdAt).format("MMMM Do, YYYY h:mm:ss A")}
                </td>
                <td>
                  {document.downloads}
                </td>
                <td>
                  <Button
                    color="primary"
                    size="sm"
                    onClick={() => doDownload(document)}>
                    Download
                  </Button>
                  {' '}
                  <Button
                    color="success"
                    size="sm"
                    onClick={() => fetchShareLink(document)}>
                    Share
                  </Button>
                </td>
              </tr>
            ))
          }
        </tbody>
      </Table>
    </div>
  );
};

export default DocumentList;
