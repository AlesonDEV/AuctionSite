import * as React from 'react';

const Providers: React.FC<{children: React.ReactNode}> = ({children}) => {
    return (
        <React.Fragment>
            {children}
        </React.Fragment>
    );
};

export default Providers