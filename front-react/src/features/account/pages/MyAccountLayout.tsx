import React from 'react';
import Box from "@mui/joy/Box";
import {Divider, Link} from "@mui/joy";

const MyAccountLayout: React.FC<{children: React.ReactNode}> = ({children}) => {
    return (
        <Box sx={{ width: '100vw', minHeight: '100dvh'}}>
            <Box sx={{
                display: 'grid',
                gridTemplateColumns: '1fr 3fr',
            }}>
                <Box>
                    <Box sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        gap: '1rem',
                        padding: '2rem',
                    }}>
                        <Box>
                            <Link
                                href={'/account/auctions'}
                                variant={'solid'}
                                color={'success'}
                                sx={{
                                    padding: '0.4rem'
                                }}
                                underline="none"
                            >My Auctions</Link>
                        </Box>
                        <Box>
                            <Link
                                href={'/account/auctions/create'}
                                variant={'solid'}
                                color={'success'}
                                sx={{
                                    padding: '0.4rem'
                                }}
                                underline="none"
                            >Create Auction</Link>
                        </Box>
                    </Box>
                    <Divider
                        sx={{
                            marginLeft: '2rem',
                            transform: 'rotate(90deg)',
                        }}
                    />
                </Box>
                <Box>{children}</Box>
            </Box>
        </Box>
    );
};

export default MyAccountLayout;
